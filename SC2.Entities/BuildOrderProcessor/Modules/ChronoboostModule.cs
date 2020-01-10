using System;
using System.Collections.Generic;
using System.Linq;
using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class ChronoboostModule : BuildManagerModuleBase
    {
        public override string ModuleName
        {
            get { return "ChronoboostModule"; }
        }

        public override void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
            this.ChangeTimerForItems(stats.GetStatsWithKeyContains("ChronoTimer"), stats);
            this.ChangeTimerForItems(stats.GetStatsWithKeyContains("ChronoBuzy"), stats);
            this.ChangeTimerForItems(stats.GetStatsWithKeyContains("NormalBuzy"), stats);
        }

        public override void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            this.ProcessBoostPossibleItem(boItem, item, stats);
            this.ProcessChronoboostItem(boItem, item, stats);
            this.AdjustAvailableBoost(boItem, item, stats);
        }

        public override void AdjustModuleStatsByUndoItem(BuildOrderProcessorItem undoBoItem, BuildOrderProcessorItem newLastItem)
        {
            if (undoBoItem.ItemName == "Chronoboost")
            {
                // Recalculate boosted item finish time
                int boostItemOrder = newLastItem.StatisticsProvider.GetStatValueByName("LastItemOrder");
                int boostProdIndex = newLastItem.StatisticsProvider.GetStatValueByName("LastItemProdBuildingIndex");

                if (boostItemOrder == 0)
                {
                    return;
                }

                BuildOrderProcessorItem boostBoItem = this.BuildOrder.GetBuildOrderItemsClone().First(p => p.Order == boostItemOrder);
                BuildItemEntity boostItem = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem(boostBoItem.ItemName);

                int previousChronoTimer = newLastItem.StatisticsProvider.GetStatValueByName("ChronoTimer" + boostItem.ProductionBuildingName + boostProdIndex);

                boostBoItem.FinishedSecond = boostBoItem.SecondInTimeLine + this.CalculateBuildTimeForItem(boostItem.BuildTimeInSeconds, previousChronoTimer);
            }
        }

        private void ProcessBoostPossibleItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            if (item.ItemType == BuildItemTypeEnum.Unit || item.ItemType == BuildItemTypeEnum.Upgrade)
            {
                var prodBuilding = this.GetProdBuildingNameForItem(stats, item);

                if (!string.IsNullOrEmpty(prodBuilding))
                {
                    this.ApplyBuzyTimers(boItem, item, stats, prodBuilding);

                    stats.SetItemCountForName("LastItemOrder", boItem.Order);
                    stats.SetItemCountForName("LastItemProdBuildingIndex", Convert.ToInt32(prodBuilding.Substring(item.ProductionBuildingName.Length)));
                }
            }
        }

        private void ProcessChronoboostItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            if (item.ItemType == BuildItemTypeEnum.Special && item.Name == "Chronoboost")
            {
                if (stats.GetStatValueByName("ChronoboostAvailable") == 0)
                {
                    throw new ApplicationException("It is not possible to apply chronoboost at this moment!");
                }

                // Apply chronoboost calculations
                int boostItemOrder = stats.GetStatValueByName("LastItemOrder");
                int boostProdIndex = stats.GetStatValueByName("LastItemProdBuildingIndex");

                if (boostItemOrder == 0)
                {
                    return;
                }

                int boostLength = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem("Chronoboost").BuildTimeInSeconds;

                BuildOrderProcessorItem boostBoItem = this.BuildOrder.GetBuildOrderItemsClone().First(p => p.Order == boostItemOrder);
                BuildItemEntity boostItem = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem(boostBoItem.ItemName);

                int previousChronoTimer = stats.GetStatValueByName("ChronoTimer" + boostItem.ProductionBuildingName + boostProdIndex);

                //int boostApplyPoint = boostBoItem.SecondInTimeLine + previousChronoTimer;

                int buildTime = boostBoItem.FinishedSecond - (boostBoItem.SecondInTimeLine + previousChronoTimer);

                int secondsToChronoboost;
                bool isEnoughEnergy = this.IsChronoboostPossibleWhileBuilding(boostBoItem.FinishedSecond - boostBoItem.SecondInTimeLine, stats, out secondsToChronoboost);
                if (!isEnoughEnergy)
                {
                    throw new ApplicationException("Chronoboost is unavailable");
                }

                if (previousChronoTimer < secondsToChronoboost)
                {
                    buildTime -= (secondsToChronoboost - previousChronoTimer);   
                }

                int boostAmount = (buildTime - this.CalculateBuildTimeForItem(buildTime, boostLength));
                boostBoItem.FinishedSecond -= boostAmount;

                int normalBuzy = stats.GetStatValueByName("NormalBuzy" + boostItem.ProductionBuildingName + boostProdIndex);

                if (normalBuzy - (boostLength + boostAmount) > 0)
                {
                    stats.SetItemCountForName("NormalBuzy" + boostItem.ProductionBuildingName + boostProdIndex, normalBuzy - (boostLength + boostAmount));   
                }
                else
                {
                    stats.RemoveStat("NormalBuzy" + boostItem.ProductionBuildingName + boostProdIndex);
                }

                stats.SetItemCountForName("ChronoTimer" + boostItem.ProductionBuildingName + boostProdIndex, boostLength + previousChronoTimer);

                int chronoBuzyTimer = (boostBoItem.FinishedSecond - boItem.SecondInTimeLine) > (boostLength + previousChronoTimer)
                                          ? (boostLength + previousChronoTimer)
                                          : (boostBoItem.FinishedSecond - boItem.SecondInTimeLine);
                stats.SetItemCountForName("ChronoBuzy" + boostItem.ProductionBuildingName + boostProdIndex, chronoBuzyTimer);

                var castModule = this.BuildManagerConfiguration.BuildManagerModules.First(p => p is CastModule) as CastModule;
                castModule.UseCast(stats);
            }
        }

        private void AdjustAvailableBoost(BuildOrderProcessorItem lastAddedBoItem, BuildItemEntity lastAddedItem, BuildItemStatistics stats)
        {
            if (lastAddedItem.Name == Consts.DefaultStateItemName) return;

            BuildOrderProcessorItem boBoostedItem;
            BuildItemEntity boostedItem;

            if (lastAddedItem.ItemType == BuildItemTypeEnum.Unit || lastAddedItem.ItemType == BuildItemTypeEnum.Upgrade)
            {
                boBoostedItem = lastAddedBoItem;
                boostedItem = lastAddedItem;
            }
            else
            {
                int boostItemOrder = stats.GetStatValueByName("LastItemOrder");
                boBoostedItem = this.BuildOrder.GetBuildOrderItemsClone().First(p => p.Order == boostItemOrder);
                boostedItem = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem(boBoostedItem.ItemName);
            }

            this.SetAvailableBoost(boBoostedItem, boostedItem, stats);
        }

        private void SetAvailableBoost(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            int boostLength = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem("Chronoboost").BuildTimeInSeconds;
            int boostProdIndex = stats.GetStatValueByName("LastItemProdBuildingIndex");

            int chronoTimer = stats.GetStatValueByName("ChronoTimer" + item.ProductionBuildingName + boostProdIndex);
            int buildTime = boItem.FinishedSecond - boItem.SecondInTimeLine;

            int availableCasts = buildTime <= chronoTimer ? 0 : (int)Math.Ceiling((double)(buildTime - chronoTimer) / boostLength);
            int secondsToChronoboost;
            bool isEnoughEnergy = this.IsChronoboostPossibleWhileBuilding(buildTime, stats, out secondsToChronoboost);

            if (boItem.SecondInTimeLine + secondsToChronoboost >= boItem.FinishedSecond)
            {
                isEnoughEnergy = false;
            }
            stats.SetItemCountForName("ChronoboostAvailable", (availableCasts > 0 && isEnoughEnergy) ? 1 : 0);
        }

        private bool IsChronoboostPossibleWhileBuilding(int buildTime, BuildItemStatistics stats, out int secondsToPossibleChronoboost)
        {
            var castModule = this.BuildManagerConfiguration.BuildManagerModules.First(p => p is CastModule);

            var tempStats = new BuildItemStatistics(this.BuildManagerConfiguration.RaceConstants, stats.CloneItemsCountDictionary());

            for (int i = 0; i < buildTime; i++)
            {
                castModule.AdjustModuleStatsForStep(tempStats);

                if (tempStats.GetStatValueByName(CastModule.TotalCasts) > 0)
                {
                    secondsToPossibleChronoboost = i;
                    return true;
                }
            }

            secondsToPossibleChronoboost = 0;
            return false;
        }

        private int CalculateBuildTimeForItem(int unboostedTime, int boostTime)
        {
            var neededChronoTime = unboostedTime / 1.5;

            int resultBuildTime;

            if (neededChronoTime <= boostTime)
            {
                resultBuildTime = (int)Math.Round(neededChronoTime);
            }
            else
            {
                var doneTime = unboostedTime * boostTime / neededChronoTime;
                resultBuildTime = (int)Math.Floor(boostTime + (unboostedTime - doneTime));
            }

            return resultBuildTime;
        }

        private void ApplyBuzyTimers(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats, string prodBuilding)
        {
            int chronoTimer = stats.GetStatValueByName("ChronoTimer" + prodBuilding);
            if (chronoTimer != 0)
            {
                boItem.FinishedSecond = boItem.SecondInTimeLine + this.CalculateBuildTimeForItem(item.BuildTimeInSeconds, chronoTimer);

                int chronoBuzyTimer = (boItem.FinishedSecond - boItem.SecondInTimeLine) > chronoTimer
                          ? chronoTimer
                          : (boItem.FinishedSecond - boItem.SecondInTimeLine);

                stats.SetItemCountForName("ChronoBuzy" + prodBuilding, chronoBuzyTimer);
            }
            else
            {
                stats.SetItemCountForName("NormalBuzy" + prodBuilding, item.BuildTimeInSeconds);
            }
        }

        private void ChangeTimerForItems(IEnumerable<KeyValuePair<string, int>> list, BuildItemStatistics stats)
        {
            foreach (var prodBuilding in list)
            {
                stats.ChangeItemCountForName(prodBuilding.Key, -1);

                if (stats.GetStatValueByName(prodBuilding.Key) == 0)
                {
                    stats.RemoveStat(prodBuilding.Key);
                }
            }
        }

        private string GetProdBuildingNameForItem(BuildItemStatistics stats, BuildItemEntity item)
        {
            string result = this.GetFreeChronoboostedProdBuildingForItem(stats, item);

            if (string.IsNullOrEmpty(result))
            {
                result = this.GetFirstNormalProdBuilding(stats, item);
            }

            return result;
        }

        private string GetFreeChronoboostedProdBuildingForItem(BuildItemStatistics stats, BuildItemEntity item)
        {
            string prodBuilding = string.Empty;

            var chronoedProdBuildings = stats.GetStatsWithKeyContains("ChronoTimer" + item.ProductionBuildingName);
            var buzyChronoedProdBuildings = stats.GetStatsWithKeyContains("ChronoBuzy" + item.ProductionBuildingName);

            if (chronoedProdBuildings.Count > buzyChronoedProdBuildings.Count)
            {
                // Use free chronoed building with maximum chronoTimer
                var chronoTimer = 0;
                var buzyProdNames = buzyChronoedProdBuildings.Select(p => p.Key).ToList();
                foreach (var chronoedProdBuilding in chronoedProdBuildings)
                {
                    if (!buzyProdNames.Contains(chronoedProdBuilding.Key) && chronoedProdBuilding.Value > chronoTimer)
                    {
                        chronoTimer = chronoedProdBuilding.Value;
                        prodBuilding = chronoedProdBuilding.Key.Substring("ChronoTimer".Length);
                    }
                }
            }

            return prodBuilding;
        }

        private string GetFirstNormalProdBuilding(BuildItemStatistics stats, BuildItemEntity item)
        {
            var totalBuzyProdBuilding = stats.GetStatValueByName(item.ProductionBuildingName + Consts.BuzyBuildItemPostfix);
            var buzyNormalProdBuildings = stats.GetStatsWithKeyContains("NormalBuzy" + item.ProductionBuildingName);
            var buzyProdNames = buzyNormalProdBuildings.Select(p => p.Key).ToList();

            if (totalBuzyProdBuilding > buzyNormalProdBuildings.Count)
            {
                for (int i = 1; i <= totalBuzyProdBuilding; i++)
                {
                    string tmpBuildingName = item.ProductionBuildingName + i;
                    if (!buzyProdNames.Contains(tmpBuildingName))
                    {
                        return tmpBuildingName;
                    }
                }
            }

            return string.Empty;
        }
    }
}
