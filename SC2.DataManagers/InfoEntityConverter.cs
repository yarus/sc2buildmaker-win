using System;
using System.Collections.Generic;
using System.Linq;
using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Actions;
using SC2.Entities.BuildItems.Requirements;
using SC2.Entities.BuildOrderProcessor;
using SC2.PublicData;

namespace SC2.DataManagers
{
    public class InfoEntityConverter
    {
        public static SC2VersionEntity Convert(SC2VersionInfo item)
        {
            var result = new SC2VersionEntity
            {
                VersionID = item.VersionID,
                AddonID = item.AddonID,
                GlobalConstants = item.GlobalSettings,
                RaceSettingsDictionary = new RaceSettingsEntityDictionary()
            };

            foreach (var raceSettingsInfo in item.RaceSettingsList)
            {
                var raceSettingsEntity = Convert(raceSettingsInfo);
                result.RaceSettingsDictionary.AddRaceSettings(raceSettingsEntity);
            }

            return result;
        }

        public static SC2VersionInfo Convert(SC2VersionEntity item)
        {
            var result = new SC2VersionInfo
            {
                VersionID = item.VersionID,
                AddonID = item.AddonID,
                GlobalSettings = item.GlobalConstants,
            };

            foreach (var entity in item.RaceSettingsDictionary.GetRaceSettingsList())
            {
                var info = Convert(entity);
                result.RaceSettingsList.Add(info);
            }

            return result;
        }

        public static RaceSettingsEntity Convert(RaceSettingsInfo item)
        {
            var result = new RaceSettingsEntity
            {
                Race = (RaceEnum) Enum.Parse(typeof (RaceEnum), item.Race),
                Constants = item.Constants,
                ItemsDictionary = new BuildItemsDictionary(),
                Modules = new BuildManagerModulesList()
            };

            foreach (var buildItemInfo in item.BuildItems)
            {
                var buildItemEntity = Convert(buildItemInfo);
                result.ItemsDictionary.AddItem(buildItemEntity);
            }

            foreach (var raceModule in item.RaceModules)
            {
                var module = BuildManagerModuleFactory.GetModule(raceModule);
                result.Modules.Add(module);
            }

            return result;
        }

        public static RaceSettingsInfo Convert(RaceSettingsEntity item)
        {
            var result = new RaceSettingsInfo
            {
                Race = item.Race.ToString(),
                Constants = item.Constants
            };

            foreach (var buildItemEntity in item.ItemsDictionary.Clone().Values)
            {
                var itemInfo = Convert(buildItemEntity);
                result.BuildItems.Add(itemInfo);
            }

            foreach (var raceModule in item.Modules)
            {
                result.RaceModules.Add(raceModule.ModuleName);
            }

            return result;
        }

        public static BuildItemEntity Convert(BuildItemInfo item)
        {
            var result = new BuildItemEntity
            {
                BuildTimeInSeconds = item.BuildTimeInSeconds,
                CostGas = item.CostGas,
                CostMinerals = item.CostMinerals,
                CostSupply = item.CostSupply,
                DisplayName = item.DisplayName,
                ImagePath = item.ImagePath,
                ItemType = (BuildItemTypeEnum) Enum.Parse(typeof (BuildItemTypeEnum), item.ItemType),
                Name = item.Name,
                ProductionBuildingName = item.ProductionBuildingName
            };

            AddRequirement(item.OrderRequirements, result.OrderRequirements);
            AddRequirement(item.ProduceRequirements, result.ProduceRequirements);

            AddActions(item.OrderedActions, result.OrderedActions);
            AddActions(item.ProducedActions, result.ProducedActions);

            return result;
        }

        private static void AddRequirement(IEnumerable<ItemWithAttributesInfo> infos, List<IBuildItemRequirement> entities)
        {
            entities.AddRange(infos.Select(BuildItemRequirementFactory.ConstructRequirement));
        }

        private static void AddActions(IEnumerable<ItemWithAttributesInfo> infos, IList<IBuildItemAction> resultList)
        {
            foreach (var action in infos)
            {
                var actionEntity = BuildItemActionsFactory.ConstructAction(action);
                resultList.Add(actionEntity);
            }
        }

        public static BuildItemInfo Convert(BuildItemEntity item)
        {
            var result = new BuildItemInfo
            {
                BuildTimeInSeconds = item.BuildTimeInSeconds,
                CostGas = item.CostGas,
                CostMinerals = item.CostMinerals,
                CostSupply = item.CostSupply,
                DisplayName = item.DisplayName,
                ImagePath = item.ImagePath,
                ItemType = item.ItemType.ToString(),
                Name = item.Name,
                ProductionBuildingName = item.ProductionBuildingName
            };

            AddActions(item.OrderedActions, result.OrderedActions);
            AddActions(item.ProducedActions, result.ProducedActions);
            AddRequirements(item.OrderRequirements, result.OrderRequirements);
            AddRequirements(item.ProduceRequirements, result.ProduceRequirements);

            return result;
        }

        private static void AddRequirements(IEnumerable<IBuildItemRequirement> requirements, IList<ItemWithAttributesInfo> resultList)
        {
            foreach (var req in requirements)
            {
                resultList.Add(req.GetAttributesInfo());
            }
        }

        private static void AddActions(IEnumerable<IBuildItemAction> actions, IList<ItemWithAttributesInfo> resultList)
        {
            foreach (var itemAction in actions)
            {
                resultList.Add(itemAction.GetAttributesInfo());
            }
        }

        public static BuildOrderInfo Convert(BuildOrderEntity buildOrder)
        {
            var result = new BuildOrderInfo
            {
                Name = buildOrder.Name,
                Description = buildOrder.Description,
                Race = buildOrder.Race.ToString(),
                VsRace = buildOrder.VsRace.ToString(),
                SC2VersionID = buildOrder.SC2VersionID,
                AddonID = buildOrder.AddonID
            };

            foreach (var item in buildOrder.BuildOrderItems)
            {
                result.BuildOrderItems.Add(item);
            }

            return result;
        }

        public static BuildOrderEntity Convert(BuildOrderInfo item)
        {
            var result = new BuildOrderEntity
            {
                Name = item.Name,
                Description = item.Description,
                Race = (RaceEnum)Enum.Parse(typeof(RaceEnum), item.Race),
                VsRace = (RaceEnum)Enum.Parse(typeof(RaceEnum), item.VsRace),
                SC2VersionID = item.SC2VersionID,
								AddonID = item.AddonID
            };

            foreach (var buildItem in item.BuildOrderItems)
            {
                result.BuildOrderItems.Add(buildItem);
            }

            return result;
        }
    }
}
