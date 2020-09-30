using System.Collections.Generic;
using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Actions;
using SC2.Entities.BuildItems.Requirements;
using SC2.Entities.BuildOrderProcessor.Modules;
using SC2.PublicData;

namespace SC2.UnitTests.TestData.LOTV
{
    public static class TestDataFixture
	{
		public static SC2VersionEntity GetVersionEntity()
		{
			var result = new SC2VersionEntity();
			result.VersionID = "5.0.3";
			result.AddonID = "LOTV";
			result.GlobalConstants = GetGlobalConstants();
			result.RaceSettingsDictionary = new RaceSettingsEntityDictionary();

			result.RaceSettingsDictionary.AddRaceSettings(GetZergRaceSettings());
			result.RaceSettingsDictionary.AddRaceSettings(GetProtossRaceSettings());
			result.RaceSettingsDictionary.AddRaceSettings(GetTerranRaceSettings());

			return result;
		}

		public static RaceSettingsEntity GetProtossRaceSettings()
		{
			var settings = new RaceSettingsEntity();
			settings.Race = RaceEnum.Protoss;
			settings.Constants = GetProtossRaceConstants();
            //settings.Modules = new BuildManagerModulesList { new ResourceModule(), new LotvChronoboostModule(), new IdleModule() };
		    settings.Modules = new BuildManagerModulesList { new ResourceModule(), new CastModule(), new ChronoboostModule(), new IdleModule() };
            settings.ItemsDictionary = GetAdjustedItemsDictionary(ProtossBuildItemsDictionary.GenerateBuildItemsDictionary());
			return settings;
		}

		public static RaceSettingsEntity GetTerranRaceSettings()
		{
			var settings = new RaceSettingsEntity();
			settings.Race = RaceEnum.Terran;
			settings.Constants = GetTerranRaceConstants();
			settings.Modules = new BuildManagerModulesList { new ResourceModule(), new CastModule(), new IdleModule() };
			settings.ItemsDictionary = GetAdjustedItemsDictionary(TerranBuildItemsDictionary.GenerateBuildItemsDictionary());
			return settings;
		}

		public static RaceSettingsEntity GetZergRaceSettings()
		{
			var settings = new RaceSettingsEntity();
			settings.Race = RaceEnum.Zerg;
			settings.Constants = GetZergRaceConstants();
            settings.Modules = new BuildManagerModulesList { new ResourceModule(), new CastModule(), new LotvLarvaModule(), new IdleModule() };
			settings.ItemsDictionary = GetAdjustedItemsDictionary(ZergBuildItemsDictionary.GenerateBuildItemsDictionary());
			return settings;
		}

		private static BuildItemsDictionary GetAdjustedItemsDictionary(BuildItemsDictionary dict)
		{
			var result = dict.Clone();

			foreach (var item in dict.Clone().Values)
			{
				item.OrderedActions.Add(new ChangeStatisticAction(item.Name + Consts.BuildItemOnBuildingPostfix, 1));
				item.ProducedActions.Add(new ChangeStatisticAction(item.Name + Consts.BuildItemOnBuildingPostfix, -1));
				item.ProducedActions.Add(new ChangeStatisticAction(item.Name, 1));

				if (!string.IsNullOrEmpty(item.ProductionBuildingName))
				{
					item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(item.ProductionBuildingName));
					item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(item.ProductionBuildingName, 1));
					item.ProduceRequirements.Add(new StatLessThenStatRequirement(item.ProductionBuildingName + Consts.BuzyBuildItemPostfix, item.ProductionBuildingName));

					item.OrderedActions.Add(new ChangeStatisticAction(item.ProductionBuildingName + Consts.BuzyBuildItemPostfix, 1));
					item.ProducedActions.Add(new ChangeStatisticAction(item.ProductionBuildingName + Consts.BuzyBuildItemPostfix, -1));
				}

				if (item.CostMinerals > 0)
				{
					item.OrderRequirements.Add(new OrBuildItemRequirement(
							new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.Minerals, item.CostMinerals),
							new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.WorkersOnMinerals)));

					item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.Minerals, item.CostMinerals));
				}

				if (item.CostGas > 0)
				{
					item.OrderRequirements.Add(new OrBuildItemRequirement(
							new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1),
							new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.Gas, item.CostGas)));

					item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.Gas, item.CostGas));
				}

				if (item.CostSupply > 0)
				{
					item.OrderRequirements.Add(new OrBuildItemRequirement(
							new StatBiggerOrEqualThenStatWithAdditionRequirement(Consts.CoreStatistics.MaximumSupply, Consts.CoreStatistics.CurrentSupply, item.CostSupply),
							new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.BuildingNewSupply, 1)));

					item.ProduceRequirements.Add(new StatBiggerOrEqualThenStatWithAdditionRequirement(Consts.CoreStatistics.MaximumSupply, Consts.CoreStatistics.CurrentSupply, item.CostSupply));
				}
			}

			return new BuildItemsDictionary((Dictionary<string, BuildItemEntity>)result);
		}

		public static GlobalConstantsInfo GetGlobalConstants()
		{
			var consts = new GlobalConstantsInfo();
			consts.MineralsPatchesPerBase = 8;
			consts.GasPatchesPerBase = 2;
			consts.MaximumPeriodInSecondsForBuildPrediction = 600;
			consts.MineralsPerMinuteFrom3WorkersPerPatch = 140;
			consts.MineralsPerMinuteFrom2WorkersPerPatch = 112;
			consts.MineralsPerMinuteFrom1WorkerPerPatch = 56;
			consts.GasPerMinuteFrom3WorkersPerPatch = 164;
			consts.GasPerMinuteFrom2WorkersPerPatch = 120;
			consts.GasPerMinuteFrom1WorkerPerPatch = 56;
			consts.MineralsPerMinuteFrom1Mule = 225;
			return consts;
		}

		public static RaceConstantsInfo GetZergRaceConstants()
		{
			var consts = new RaceConstantsInfo();
			consts.DefaultBaseBuildingName = "Hatchery";
			consts.EnergyGeneratorBuildItemName = "Queen";
			consts.EnergyCastGenerateTime = 29;
			consts.EnergyCastLimitPerEnergyGenerator = 4;
			consts.EnergyCastCountForNewEnergyGenerator = 1;

			return consts;
		}

		public static RaceConstantsInfo GetProtossRaceConstants()
		{
			var consts = new RaceConstantsInfo();
			consts.DefaultBaseBuildingName = "Nexus";
			consts.EnergyGeneratorBuildItemName = "Nexus";
			consts.EnergyCastGenerateTime = 63;
			consts.EnergyCastLimitPerEnergyGenerator = 4;
			consts.EnergyCastCountForNewEnergyGenerator = 1;

			return consts;
		}

		public static RaceConstantsInfo GetTerranRaceConstants()
		{
			var consts = new RaceConstantsInfo();
			consts.DefaultBaseBuildingName = "CommandCenter";
			consts.EnergyGeneratorBuildItemName = "OrbitalCommand";
			consts.EnergyCastGenerateTime = 63;
			consts.EnergyCastLimitPerEnergyGenerator = 4;
			consts.EnergyCastCountForNewEnergyGenerator = 1;

			return consts;
		}
	}
}
