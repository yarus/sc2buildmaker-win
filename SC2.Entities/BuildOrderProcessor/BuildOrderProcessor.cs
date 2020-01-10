using System;
using System.Collections.Generic;
using System.Linq;
using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor
{
    public class BuildOrderProcessor
    {
        private BuildOrderProcessorData mBuildOrder;
        private readonly BuildOrderProcessorConfiguration mConfig;

        public BuildOrderProcessor(BuildOrderProcessorConfiguration config)
        {
            this.mConfig = config;
        }

        public BuildOrderEntity GetBuildEntityFormCurrentBuild()
        {
            return this.mBuildOrder.GenerateBuildOrderEntity();
        }

        public void LoadBuildDataFromEntity(BuildOrderEntity bo)
        {
            this.mBuildOrder.Name = bo.Name;
            this.mBuildOrder.Description = bo.Description;
            this.mBuildOrder.Race = bo.Race;
            this.mBuildOrder.SC2VersionID = bo.SC2VersionID;
            this.mBuildOrder.VsRace = bo.VsRace;
        }

        public void LoadBuildOrder(BuildOrderEntity bo)
        {
            this.mBuildOrder = new BuildOrderProcessorData();

            this.LoadBuildDataFromEntity(bo);

            this.mConfig.BuildManagerModules.InitBuildManagerModules(this.mBuildOrder, this.mConfig);

            if (bo.BuildOrderItems.Count == 0 || (bo.BuildOrderItems.Count > 0 && bo.BuildOrderItems[0] != Consts.DefaultStateItemName))
            {
                this.AddDefaultBuildItemToNewBuildOrder();   
            }

            foreach (var item in bo.BuildOrderItems)
            {
                this.AddBuildItem(item);
            }
        }

        public void CreateNewBuildOrder()
        {
            var bo = new BuildOrderEntity
            {
                Name = "New build order",
                Race = this.mConfig.Race,
                SC2VersionID = this.mConfig.SC2VersionID,
                VsRace = RaceEnum.NotDefined,
                Description = string.Empty
            };

            this.LoadBuildOrder(bo);
        }

        public void AddBuildItem(string buildItemName)
        {
            int secondsToAppropriateItem;
            BuildItemEntity buildItem;
            BuildItemStatistics statProvider;

            this.GetCurrentStateData(buildItemName, out buildItem, out statProvider);

            this.FindAppropriateSecondInTimeLine(buildItem, statProvider, out secondsToAppropriateItem);

            int secondInTimeLine = this.mBuildOrder.LastBuildItem != null
                                       ? this.mBuildOrder.LastBuildItem.SecondInTimeLine
                                       : 0;

            var buildOrderItem = this.CreateBuildOrderItemWithAdjustedResourcesAndStatistics(
                secondInTimeLine + secondsToAppropriateItem, 
                buildItem,
                statProvider);

            this.mBuildOrder.AddBuildItem(buildOrderItem);
        }

        public void UndoLastBuildItem()
        {
            if (this.mBuildOrder.LastBuildItem.ItemName == Consts.DefaultStateItemName) return;

            this.mConfig.BuildManagerModules.AdjustModulesStatsForUndo(this.mBuildOrder.LastBuildItem, this.mBuildOrder.GetItemBefore(this.mBuildOrder.LastBuildItem));

            this.mBuildOrder.RemoveLastItem();
        }

        public BuildItemStatistics CurrentStatistics
        {
            get 
            {
                return this.mBuildOrder.LastBuildItem != null ? this.mBuildOrder.LastBuildItem.StatisticsProvider : null;
            }
        }

        public BuildOrderProcessorData CurrentBuildOrder
        {
            get { return this.mBuildOrder; }
        }

        #region Common methods

        private void GetCurrentStateData(string buildItemName, out BuildItemEntity buildItem, out BuildItemStatistics statProvider)
        {
            buildItem = this.mConfig.BuildItemsDictionary.GetItem(buildItemName);

            if (buildItem == null)
            {
                throw new ArgumentException("Unknown build item");
            }

            var previousStats = this.mBuildOrder.LastBuildItem != null
                                    ? this.mBuildOrder.LastBuildItem.StatisticsProvider.CloneItemsCountDictionary()
                                    : new Dictionary<string, int>();

            statProvider = new BuildItemStatistics(this.mConfig.RaceConstants, previousStats);
        }

        private void FindAppropriateSecondInTimeLine(BuildItemEntity buildItem, BuildItemStatistics stats, out int secondsToAppropriateItem)
        {
            secondsToAppropriateItem = 0;

            while ((!this.IsCurrentSecondHasEnoughResourcesToBuildItem(buildItem, stats)
                || !this.HasFreeProductionBuilding(stats, buildItem)
                || !this.IsRequirementsSatisfied(buildItem, stats))
                && secondsToAppropriateItem < this.mConfig.GlobalConstants.MaximumPeriodInSecondsForBuildPrediction)
            {
                secondsToAppropriateItem++;

                this.mConfig.BuildManagerModules.AdjustModulesStatsForStep(stats);

                this.AdjustStatisticsByFinishedItems(this.mBuildOrder.LastBuildItem.SecondInTimeLine + secondsToAppropriateItem, stats);

                this.CheckForResourceChangePossibility(buildItem, stats);
            }

            if (secondsToAppropriateItem == this.mConfig.GlobalConstants.MaximumPeriodInSecondsForBuildPrediction)
            {
                throw new ApplicationException("There is no appropriate point in timeline when it is possible to build this item.");
            }
        }

        private bool IsRequirementsSatisfied(BuildItemEntity buildItem, BuildItemStatistics stats)
        {
            if (buildItem.ProduceRequirements == null || buildItem.ProduceRequirements.Count == 0)
            {
                return true;
            }

            return buildItem.ProduceRequirements.All(req => req.IsRequirementSatisfied(stats));
        }

        private bool HasFreeProductionBuilding(BuildItemStatistics currentStatProvider, BuildItemEntity buildItem)
        {
            if (string.IsNullOrEmpty(buildItem.ProductionBuildingName))
            {
                return true;
            }

            int productionBuildingsCount = currentStatProvider.GetStatValueByName(buildItem.ProductionBuildingName);

            int buzyProdCount = currentStatProvider.GetStatValueByName(buildItem.ProductionBuildingName + Consts.BuzyBuildItemPostfix);

            return productionBuildingsCount > buzyProdCount;
        }

        private void AddDefaultBuildItemToNewBuildOrder()
        {
            if (this.mBuildOrder.LastBuildItem == null)
            {
                var item = this.mConfig.BuildItemsDictionary.GetItem(Consts.DefaultStateItemName);
                if (item == null)
                {
                    throw new ApplicationException("Default build item not specified");
                }

                this.mBuildOrder.AddBuildItem(this.CreateBuildOrderItemWithAdjustedResourcesAndStatistics(1, item, new BuildItemStatistics(this.mConfig.RaceConstants)));
            }
        }

        private void CheckForResourceChangePossibility(BuildItemEntity item, BuildItemStatistics statisticProvider)
        {
            if (item.CostSupply > 0 && (statisticProvider.CurrentSupply + item.CostSupply > statisticProvider.MaximumSupply))
            {
                if (statisticProvider.GetStatValueByName(Consts.CoreStatistics.BuildingNewSupply) == 0)
                {
                    throw new ApplicationException("New item requires more supply but there is no supply changers in build order");
                }
            }

            if (item.CostMinerals > 0)
            {
                if (statisticProvider.Minerals < item.CostMinerals && statisticProvider.GetStatValueByName(Consts.CoreStatistics.WorkersOnMinerals) == 0
                    && statisticProvider.GetStatValueByName("MineralScv" + Consts.BuildItemOnBuildingPostfix) == 0
                    && statisticProvider.GetStatValueByName(Consts.DefaultStateItemName + Consts.BuildItemOnBuildingPostfix) == 0)
                {
                    throw new ApplicationException("New item requires minerals but there is no mineral harvesters applied in build order");
                }
            }

            if (item.CostGas > 0)
            {
                if (statisticProvider.Gas < item.CostGas && statisticProvider.GetStatValueByName(Consts.CoreStatistics.WorkersOnGas) == 0 
                    && statisticProvider.GetStatValueByName("GasScv" + Consts.BuildItemOnBuildingPostfix) == 0
                    && statisticProvider.GetStatValueByName(Consts.DefaultStateItemName + Consts.BuildItemOnBuildingPostfix) == 0)
                {
                    throw new ApplicationException("New item requires gas but there is no gas harvesters applied in build order");
                }
            }
        }

        private BuildOrderProcessorItem CreateBuildOrderItemWithAdjustedResourcesAndStatistics(int secondInTimeLine, BuildItemEntity item, BuildItemStatistics stats)
        {
            stats.CurrentSupply += item.CostSupply;

            var newItem = new BuildOrderProcessorItem(secondInTimeLine, item, stats, this.GetBuildItemOrder());

            this.RunActions(item.OrderedActions, stats);

            this.mConfig.BuildManagerModules.AdjustModuleStatsByStartedItem(newItem, item, stats);

            return newItem;
        }

        private void RunActions(List<IBuildItemAction> actions, BuildItemStatistics stats)
        {
            if (actions == null || actions.Count == 0) return;

            foreach (var action in actions)
            {
                action.DoAction(stats);
            }
        }

        private int GetBuildItemOrder()
        {
            return this.mBuildOrder.LastBuildItem != null ? this.mBuildOrder.LastBuildItem.Order + 1 : 0;
        }

        private bool IsCurrentSecondHasEnoughResourcesToBuildItem(BuildItemEntity item, BuildItemStatistics stats)
        {
            return stats.Minerals >= item.CostMinerals 
                && stats.Gas >= item.CostGas
                && (item.CostSupply == 0 || (stats.CurrentSupply + item.CostSupply <= stats.MaximumSupply));
        }

        private void AdjustStatisticsByFinishedItems(int currentSecond, BuildItemStatistics currentStatistics)
        {
            var finishedItems = this.mBuildOrder.GetFinishedItemsClone(currentSecond);

            if (finishedItems.Count == 0)
            {
                return;
            }

            foreach (var buildOrderItem in finishedItems)
            {
                var buildItem = this.mConfig.BuildItemsDictionary.GetItem(buildOrderItem.ItemName);

                this.RunActions(buildItem.ProducedActions, currentStatistics);
            }

            this.mConfig.BuildManagerModules.AdjustModelStatsByFinishedItems(finishedItems, currentStatistics);
        }

        #endregion
    }
}