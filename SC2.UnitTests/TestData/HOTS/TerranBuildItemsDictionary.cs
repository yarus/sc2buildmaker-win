using System.Collections.Generic;
using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Actions;
using SC2.Entities.BuildItems.Requirements;
using SC2.Entities.BuildOrderProcessor.Modules;

namespace SC2.UnitTests.TestData.HOTS
{
    public class TerranBuildItemsDictionary
	{
		public static BuildItemsDictionary GenerateBuildItemsDictionary()
		{
			var result = new BuildItemsDictionary();

            // Special
            result.AddItem(DefaultItem);
            
            result.AddItem(CallMule);
            result.AddItem(GasScv);
		    result.AddItem(MineralScv);
            result.AddItem(GoOutScv);

            result.AddItem(LiftRaxFromReactor);
            result.AddItem(LiftRaxFromTechLab);
            result.AddItem(LandRaxOnReactor);
            result.AddItem(LandRaxOnTechLab);

            result.AddItem(LiftFactoryFromReactor);
            result.AddItem(LiftFactoryFromTechLab);
            result.AddItem(LandFactoryOnReactor);
            result.AddItem(LandFactoryOnTechLab);

            result.AddItem(LiftStarportFromReactor);
            result.AddItem(LiftStarportFromTechLab);
            result.AddItem(LandStarportOnReactor);
            result.AddItem(LandStarportOnTechLab);

            result.AddItem(ScannerSweep);
            result.AddItem(ReturnScv);
            result.AddItem(CallSupplyDrop);
            result.AddItem(SalvageBunker);

            result.AddItem(StartIdle);
            result.AddItem(StopIdleIn3Seconds);
            result.AddItem(StopIdleIn5Seconds);
            result.AddItem(StopIdleIn10Seconds);

            // Units
            result.AddItem(Scv);
            result.AddItem(Marine);
            result.AddItem(MarineOnReactor);

            result.AddItem(Marauder);
            result.AddItem(Reaper);
            result.AddItem(ReaperOnReactor);
            result.AddItem(Ghost);
            result.AddItem(Hellion);
            result.AddItem(HellionOnReactor);
            result.AddItem(WidowMine);
            result.AddItem(WidowMineOnReactor);
            result.AddItem(Hellbat);
            result.AddItem(HellbatOnReactor);
            result.AddItem(SiegeTank);
            result.AddItem(Thor);
            result.AddItem(Viking);
            result.AddItem(VikingOnReactor);
            result.AddItem(Medivac);
            result.AddItem(MedivacOnReactor);
            result.AddItem(Raven);
            result.AddItem(Banshee);
            result.AddItem(BattleCruiser);
//            result.AddItem(DoubleMarines);
//            result.AddItem(DoubleReapers);
//            result.AddItem(DoubleHellions);
//            result.AddItem(DoubleHellbat);
//            result.AddItem(DoubleWidowMines);
//            result.AddItem(DoubleVikings);
//            result.AddItem(DoubleMedivacs);

            //result.AddItem(VikingPlusMedivac);
            result.AddItem(Nuke);

            // Buildings
			result.AddItem(SupplyDepot);
			result.AddItem(CommandCenter);
			result.AddItem(Barracks);
			result.AddItem(Refinery);
			result.AddItem(OrbitalCommand);
            result.AddItem(PlanetaryFortrees);
			result.AddItem(EngineeringBay);
			result.AddItem(Bunker);
            result.AddItem(MissileTurret);
			result.AddItem(Factory);
			result.AddItem(GhostAcademy);
			result.AddItem(Starport);
			result.AddItem(Armory);
			result.AddItem(TechLabOnBarracks);
			result.AddItem(ReactorOnBarracks);
			result.AddItem(TechLabOnFactory);
			result.AddItem(ReactorOnFactory);
			result.AddItem(TechLabOnStarport);
			result.AddItem(ReactorOnStarport);
            result.AddItem(FusionCore);
            result.AddItem(SensorTower);

            // Upgrades
            result.AddItem(StimPack);
            result.AddItem(CombatShield);
            result.AddItem(ConcussiveShells);
            result.AddItem(CloakingField);

            result.AddItem(InfantryWeaponsLevel1);
            result.AddItem(InfantryArmorLevel1);
            result.AddItem(InfantryWeaponsLevel2);
            result.AddItem(InfantryArmorLevel2);

            result.AddItem(InfantryWeaponsLevel3);
            result.AddItem(InfantryArmorLevel3);
            result.AddItem(InfernalPreIgniter);
            result.AddItem(DrillingClaws);

            result.AddItem(VehicleAndShipWeaponsLevel1);
            result.AddItem(VehicleAndShipPlatingLevel1);
            result.AddItem(VehicleAndShipWeaponsLevel2);
            result.AddItem(VehicleAndShipPlatingLevel2);

            result.AddItem(VehicleAndShipWeaponsLevel3);
            result.AddItem(VehicleAndShipPlatingLevel3);
            result.AddItem(PersonalCloaking);
            result.AddItem(HiSecAutoTracking);
            
            result.AddItem(CaduceusReactor);
            result.AddItem(CorvidReactor);
            result.AddItem(DurableMaterials);
			result.AddItem(BuildingArmor);

			result.AddItem(NeosteelFrame);
			result.AddItem(BehemothReactor);
			result.AddItem(WeaponRefit);

			return result;
		}

		private static BuildItemEntity DefaultItem
		{
			get
			{
				var defaultItem = new BuildItemEntity
				{
					Name = Consts.DefaultStateItemName,
					CostSupply = 0,
					CostGas = 0,
					CostMinerals = 0,
					BuildTimeInSeconds = 4,
					ItemType = BuildItemTypeEnum.Special
				};

				defaultItem.ProducedActions.Add(new ChangeStatisticAction("WorkersOnMinerals", 6));
				defaultItem.ProducedActions.Add(new ChangeStatisticAction("WorkersOnMinerals" + Consts.BuildItemOnBuildingPostfix, -6));

				defaultItem.OrderedActions.Add(new ChangeStatisticAction("SCV", 6));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("CurrentSupply", 6));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("MaximumSupply", 11));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("BasesCount", 1));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("CommandCenter", 1));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("Minerals", 50));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("MaximumSupplyLimit", 200));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("WorkersOnMinerals" + Consts.BuildItemOnBuildingPostfix, 6));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction("TotalCasts", 0));
				defaultItem.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 2));

				return defaultItem;
			}
		}

		#region Units

		private static BuildItemEntity Scv
		{
			get
			{
				var scv = new BuildItemEntity
				{
					Name = "SCV",
					CostGas = 0,
					CostMinerals = 50,
					CostSupply = 1,
					BuildTimeInSeconds = 17,
                    ProductionBuildingName = "CommandCenter",
					ItemType = BuildItemTypeEnum.Unit
				};

				scv.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

				return scv;
			}
		}

		private static BuildItemEntity Marine
		{
			get
			{
				var marine = new BuildItemEntity
				{
					Name = "Marine",
					CostGas = 0,
					CostMinerals = 50,
					CostSupply = 1,
					BuildTimeInSeconds = 25,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Barracks"
				};

				return marine;
			}
		}

		private static BuildItemEntity Marauder
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Marauder",
					CostMinerals = 100,
					CostGas = 25,
					CostSupply = 2,
					BuildTimeInSeconds = 30,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Barracks"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnBarracks"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnBarracks", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnBarracksInUseForUnit", "TechLabOnBarracks"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnBarracksInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnBarracksInUseForUnit", -1));

				return item;
			}
		}

		private static BuildItemEntity Reaper
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Reaper",
					CostMinerals = 50,
					CostGas = 50,
					CostSupply = 1,
					BuildTimeInSeconds = 45,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Barracks"
				};

				return item;
			}
		}

		private static BuildItemEntity Ghost
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Ghost",
					CostMinerals = 200,
					CostGas = 100,
					CostSupply = 2,
					BuildTimeInSeconds = 40,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Barracks"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GhostAcademy"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnBarracks"));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnBarracks", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnBarracksInUseForUnit", "TechLabOnBarracks"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GhostAcademy", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnBarracksInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnBarracksInUseForUnit", -1));

				return item;
			}
		}

		private static BuildItemEntity Hellion
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Hellion",
					CostMinerals = 100,
					CostGas = 0,
					CostSupply = 2,
					BuildTimeInSeconds = 30,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Factory"
				};

				return item;
			}
		}

		private static BuildItemEntity WidowMine
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "WidowMine",
					CostMinerals = 75,
					CostGas = 25,
					CostSupply = 2,
					BuildTimeInSeconds = 40,
					ItemType = BuildItemTypeEnum.Unit,
					DisplayName = "Widow Mine",
					ProductionBuildingName = "Factory"
				};

				return item;
			}
		}

		private static BuildItemEntity Hellbat
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Hellbat",
					CostMinerals = 100,
					CostGas = 0,
					CostSupply = 2,
					BuildTimeInSeconds = 30,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Factory"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));

				return item;
			}
		}

		private static BuildItemEntity SiegeTank
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "SiegeTank",
					CostMinerals = 150,
					CostGas = 125,
					CostSupply = 3,
					BuildTimeInSeconds = 45,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Factory",
					DisplayName = "Siege Tank"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnFactory"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnFactory", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnFactoryInUseForUnit", "TechLabOnFactory"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnFactoryInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnFactoryInUseForUnit", -1));

				return item;
			}
		}

		private static BuildItemEntity Thor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Thor",
					CostMinerals = 300,
					CostGas = 200,
					CostSupply = 6,
					BuildTimeInSeconds = 60,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Factory"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnFactory"));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnFactory", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnFactoryInUseForUnit", "TechLabOnFactory"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnFactoryInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnFactoryInUseForUnit", -1));

				return item;
			}
		}

		private static BuildItemEntity Viking
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Viking",
					CostMinerals = 150,
					CostGas = 75,
					CostSupply = 2,
					BuildTimeInSeconds = 42,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Starport"
				};

				return item;
			}
		}

		private static BuildItemEntity Medivac
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Medivac",
					CostMinerals = 100,
					CostGas = 100,
					CostSupply = 2,
					BuildTimeInSeconds = 42,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Starport"
				};

				return item;
			}
		}

		private static BuildItemEntity Raven
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Raven",
					CostMinerals = 100,
					CostGas = 200,
					CostSupply = 2,
					BuildTimeInSeconds = 60,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Starport"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnStarport"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnStarport", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnStarportInUseForUnit", "TechLabOnStarport"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnStarportInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnStarportInUseForUnit", -1));

				return item;
			}
		}

		private static BuildItemEntity Banshee
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Banshee",
					CostMinerals = 150,
					CostGas = 100,
					CostSupply = 3,
					BuildTimeInSeconds = 60,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Starport"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnStarport"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnStarport", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnStarportInUseForUnit", "TechLabOnStarport"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnStarportInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnStarportInUseForUnit", -1));

				return item;
			}
		}

		private static BuildItemEntity BattleCruiser
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "BattleCruiser",
					CostMinerals = 400,
					CostGas = 300,
					CostSupply = 6,
					BuildTimeInSeconds = 90,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Starport",
					DisplayName = "Battle Cruiser"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FusionCore"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnStarport"));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FusionCore", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnStarport", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnStarportInUseForUnit", "TechLabOnStarport"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnStarportInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("TechLabOnStarportInUseForUnit", -1));

				return item;
			}
		}

        private static BuildItemEntity MarineOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MarineOnReactor",
                    DisplayName = "Marine on Reactor",
                    CostMinerals = 50,
                    CostGas = 0,
                    CostSupply = 1,
                    BuildTimeInSeconds = 25,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "ReactorOnBarracks"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("Marine" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Marine" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("Marine", 1));

                return item;
            }
        }

        private static BuildItemEntity ReaperOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ReaperOnReactor",
                    DisplayName = "Reaper on Reactor",
                    CostMinerals = 50,
                    CostGas = 50,
                    CostSupply = 1,
                    BuildTimeInSeconds = 45,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "ReactorOnBarracks"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("Reaper" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Reaper" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("Reaper", 1));

                return item;
            }
        }

//		private static BuildItemEntity DoubleMarines
//		{
//			get
//			{
//				var item = new BuildItemEntity
//				{
//					Name = "DoubleMarines",
//					DisplayName = "Marines x2",
//					CostMinerals = 100,
//					CostGas = 0,
//					CostSupply = 2,
//					BuildTimeInSeconds = 25,
//					ItemType = BuildItemTypeEnum.Unit,
//					ProductionBuildingName = "Barracks"
//				};
//
//				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnBarracks"));
//				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnBarracks", 1));
//				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnBarracksInUseForUnit", "ReactorOnBarracks"));
//
//				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnBarracksInUseForUnit", 1));
//				item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnBarracksInUseForUnit", -1));
//
//				item.ProducedActions.Add(new ChangeStatisticAction("Marine", 2));
//
//				return item;
//			}
//		}
        
//        private static BuildItemEntity DoubleReapers
//        {
//            get
//            {
//                var item = new BuildItemEntity
//                {
//                    Name = "DoubleReapers",
//                    DisplayName = "Reapers x2",
//                    CostMinerals = 100,
//                    CostGas = 100,
//                    CostSupply = 2,
//                    BuildTimeInSeconds = 45,
//                    ItemType = BuildItemTypeEnum.Unit,
//                    ProductionBuildingName = "Barracks"
//                };
//
//                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnBarracks"));
//                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnBarracks", 1));
//                item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnBarracksInUseForUnit", "ReactorOnBarracks"));
//
//                item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnBarracksInUseForUnit", 1));
//                item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnBarracksInUseForUnit", -1));
//
//                item.ProducedActions.Add(new ChangeStatisticAction("Reaper", 2));
//
//                return item;
//            }
//        }

        private static BuildItemEntity HellionOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "HellionOnReactor",
                    DisplayName = "Hellion on Reactor",
                    CostMinerals = 100,
                    CostGas = 0,
                    CostSupply = 2,
                    BuildTimeInSeconds = 30,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "ReactorOnFactory"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("Hellion" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Hellion" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("Hellion", 1));

                return item;
            }
        }

        private static BuildItemEntity HellbatOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "HellbatOnReactor",
                    DisplayName = "Hellbat on Reactor",
                    CostMinerals = 100,
                    CostGas = 0,
                    CostSupply = 2,
                    BuildTimeInSeconds = 30,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "ReactorOnFactory"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Hellbat" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Hellbat" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("Hellbat", 1));

                return item;
            }
        }

        private static BuildItemEntity WidowMineOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WidowMineOnReactor",
                    CostMinerals = 75,
                    CostGas = 25,
                    CostSupply = 2,
                    BuildTimeInSeconds = 40,
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Widow Mine on Reactor",
                    ProductionBuildingName = "ReactorOnFactory"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("WidowMine" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("WidowMine" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("WidowMine", 1));

                return item;
            }
        }

//		private static BuildItemEntity DoubleHellions
//		{
//			get
//			{
//				var item = new BuildItemEntity
//				{
//					Name = "DoubleHellions",
//					DisplayName = "Hellion x2",
//					CostMinerals = 200,
//					CostGas = 0,
//					CostSupply = 4,
//					BuildTimeInSeconds = 30,
//					ItemType = BuildItemTypeEnum.Unit,
//					ProductionBuildingName = "Factory"
//				};
//
//				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnFactory"));
//				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnFactory", 1));
//				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnFactoryInUseForUnit", "ReactorOnFactory"));
//
//				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnFactoryInUseForUnit", 1));
//				item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnFactoryInUseForUnit", -1));
//
//				item.ProducedActions.Add(new ChangeStatisticAction("Hellion", 2));
//
//				return item;
//			}
//		}

//        private static BuildItemEntity DoubleHellbat
//        {
//            get
//            {
//                var item = new BuildItemEntity
//                {
//                    Name = "DoubleHellbat",
//                    DisplayName = "Hellbat x2",
//                    CostMinerals = 200,
//                    CostGas = 0,
//                    CostSupply = 4,
//                    BuildTimeInSeconds = 30,
//                    ItemType = BuildItemTypeEnum.Unit,
//                    ProductionBuildingName = "Factory"
//                };
//
//                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
//                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));
//
//                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnFactory"));
//                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnFactory", 1));
//                item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnFactoryInUseForUnit", "ReactorOnFactory"));
//
//                item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnFactoryInUseForUnit", 1));
//                item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnFactoryInUseForUnit", -1));
//
//                item.ProducedActions.Add(new ChangeStatisticAction("Hellbat", 2));
//
//                return item;
//            }
//        }
//
//        private static BuildItemEntity DoubleWidowMines
//        {
//            get
//            {
//                var item = new BuildItemEntity
//                {
//                    Name = "DoubleWidowMines",
//                    DisplayName = "Widow Mine x2",
//                    CostMinerals = 150,
//                    CostGas = 50,
//                    CostSupply = 4,
//                    BuildTimeInSeconds = 40,
//                    ItemType = BuildItemTypeEnum.Unit,
//                    ProductionBuildingName = "Factory"
//                };
//
//                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnFactory"));
//                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnFactory", 1));
//                item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnFactoryInUseForUnit", "ReactorOnFactory"));
//
//                item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnFactoryInUseForUnit", 1));
//                item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnFactoryInUseForUnit", -1));
//
//                item.ProducedActions.Add(new ChangeStatisticAction("WidowMine", 2));
//
//                return item;
//            }
//        }

        private static BuildItemEntity VikingOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "VikingOnReactor",
                    DisplayName = "Viking on Reactor",
                    CostMinerals = 150,
                    CostGas = 75,
                    CostSupply = 2,
                    BuildTimeInSeconds = 42,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "ReactorOnStarport"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("Viking" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Viking" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("Viking", 1));

                return item;
            }
        }

//		private static BuildItemEntity DoubleVikings
//		{
//			get
//			{
//				var item = new BuildItemEntity
//				{
//					Name = "DoubleVikings",
//					DisplayName = "Viking x2",
//					CostMinerals = 300,
//					CostGas = 150,
//					CostSupply = 4,
//					BuildTimeInSeconds = 42,
//					ItemType = BuildItemTypeEnum.Unit,
//					ProductionBuildingName = "Starport"
//				};
//
//				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnStarport"));
//				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnStarport", 1));
//				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnStarportInUseForUnit", "ReactorOnStarport"));
//
//				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnStarportInUseForUnit", 1));
//				item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnStarportInUseForUnit", -1));
//
//				item.ProducedActions.Add(new ChangeStatisticAction("Viking", 2));
//
//				return item;
//			}
//		}

        private static BuildItemEntity MedivacOnReactor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MedivacOnReactor",
                    DisplayName = "Medivac on Reactor",
                    CostMinerals = 100,
                    CostGas = 100,
                    CostSupply = 2,
                    BuildTimeInSeconds = 42,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "ReactorOnStarport"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("Medivac" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Medivac" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("Medivac", 1));

                return item;
            }
        }

//		private static BuildItemEntity DoubleMedivacs
//		{
//			get
//			{
//				var item = new BuildItemEntity
//				{
//					Name = "DoubleMedivacs",
//					DisplayName = "Medivac x2",
//					CostMinerals = 200,
//					CostGas = 200,
//					CostSupply = 4,
//					BuildTimeInSeconds = 42,
//					ItemType = BuildItemTypeEnum.Unit,
//					ProductionBuildingName = "Starport"
//				};
//
//				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnStarport"));
//				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnStarport", 1));
//				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnStarportInUseForUnit", "ReactorOnStarport"));
//
//				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnStarportInUseForUnit", 1));
//				item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnStarportInUseForUnit", -1));
//
//				item.ProducedActions.Add(new ChangeStatisticAction("Medivac", 2));
//
//				return item;
//			}
//		}

		private static BuildItemEntity VikingPlusMedivac
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "VikingPlusMedivac",
					DisplayName = "Viking + Medivac",
					CostMinerals = 250,
					CostGas = 175,
					CostSupply = 4,
					BuildTimeInSeconds = 42,
					ItemType = BuildItemTypeEnum.Unit,
					ProductionBuildingName = "Starport"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnStarport"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnStarport", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnStarportInUseForUnit", "ReactorOnStarport"));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnStarportInUseForUnit", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("ReactorOnStarportInUseForUnit", -1));

				item.ProducedActions.Add(new ChangeStatisticAction("Medivac", 1));
				item.ProducedActions.Add(new ChangeStatisticAction("Viking", 1));

				return item;
			}
		}

		#endregion

		#region Buildings

		private static BuildItemEntity SupplyDepot
		{
			get
			{
				var supplyDepot = new BuildItemEntity
				{
					Name = "SupplyDepot",
					CostGas = 0,
					CostMinerals = 100,
					CostSupply = 0,
					BuildTimeInSeconds = 30,
					ItemType = BuildItemTypeEnum.Building,
					DisplayName = "Supply Depot"
				};

				supplyDepot.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				supplyDepot.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));
				supplyDepot.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 8));

				supplyDepot.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				supplyDepot.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));
				supplyDepot.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 8, "MaximumSupplyLimit"));
				supplyDepot.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -8));

				return supplyDepot;
			}
		}

		private static BuildItemEntity CommandCenter
		{
			get
			{
				var cc = new BuildItemEntity
				{
					Name = "CommandCenter",
					CostGas = 0,
					CostMinerals = 400,
					CostSupply = 0,
					BuildTimeInSeconds = 100,
					ItemType = BuildItemTypeEnum.Building,
					DisplayName = "Command Center"
				};

				cc.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				cc.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));
				cc.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 11));
				cc.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser + Consts.BuildItemOnBuildingPostfix, 2));

				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));
				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 11, "MaximumSupplyLimit"));
				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BasesCount, 1));
				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -11));
				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser + Consts.BuildItemOnBuildingPostfix, -2));
				cc.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 2));

				return cc;
			}
		}

		private static BuildItemEntity OrbitalCommand
		{
			get
			{
				var oc = new BuildItemEntity
				{
					Name = "OrbitalCommand",
					CostGas = 0,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 35,
					ItemType = BuildItemTypeEnum.Building,
                    ProductionBuildingName = "CommandCenter",
					DisplayName = "Orbital Command"
				};
				
				oc.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Barracks"));

                oc.OrderRequirements.Add(new StatsAdditionIsBiggerThenStatsAdditionRequirement(
                    new List<string> { "CommandCenter", ("CommandCenter" + Consts.BuildItemOnBuildingPostfix) },
                    new List<string> { "UpgradedCC", ("UpgradedCC" + Consts.BuildItemOnBuildingPostfix) }));

				oc.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Barracks", 1));
                oc.ProduceRequirements.Add(new StatLessThenStatRequirement("UpgradedCC", "CommandCenter"));

                oc.OrderedActions.Add(new ChangeStatisticAction("UpgradedCC" + Consts.BuildItemOnBuildingPostfix, 1));
                
                oc.ProducedActions.Add(new ChangeStatisticAction("UpgradedCC" + Consts.BuildItemOnBuildingPostfix, -1));
                oc.ProducedActions.Add(new ChangeStatisticAction("UpgradedCC", 1));

				return oc;
			}
		}

		private static BuildItemEntity PlanetaryFortrees
		{
			get
			{
				var pf = new BuildItemEntity
				{
					Name = "PlanetaryFortrees",
					CostGas = 150,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 50,
					ItemType = BuildItemTypeEnum.Building,
                    ProductionBuildingName = "CommandCenter",
					DisplayName = "Planetary Fortrees"
				};

				pf.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("EngineeringBay"));

                pf.OrderRequirements.Add(new StatsAdditionIsBiggerThenStatsAdditionRequirement(
                    new List<string> { "CommandCenter", ("CommandCenter" + Consts.BuildItemOnBuildingPostfix) }, 
                    new List<string> { "UpgradedCC", ("UpgradedCC" + Consts.BuildItemOnBuildingPostfix) } ));

				pf.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("EngineeringBay", 1));
                pf.ProduceRequirements.Add(new StatLessThenStatRequirement("UpgradedCC", "CommandCenter"));

                pf.OrderedActions.Add(new ChangeStatisticAction("UpgradedCC" + Consts.BuildItemOnBuildingPostfix, 1));

                pf.ProducedActions.Add(new ChangeStatisticAction("UpgradedCC" + Consts.BuildItemOnBuildingPostfix, -1));
                pf.ProducedActions.Add(new ChangeStatisticAction("UpgradedCC", 1));

				return pf;
			}
		}

		private static BuildItemEntity Barracks
		{
			get
			{
				var barracks = new BuildItemEntity
				{
					Name = "Barracks",
					CostGas = 0,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 65,
					ItemType = BuildItemTypeEnum.Building
				};

				barracks.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SupplyDepot"));
				barracks.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SupplyDepot", 1));

				barracks.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				barracks.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				barracks.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				barracks.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return barracks;
			}
		}

		private static BuildItemEntity Bunker
		{
			get
			{
				var bunker = new BuildItemEntity
				{
					Name = "Bunker",
					CostGas = 0,
					CostMinerals = 100,
					CostSupply = 0,
					BuildTimeInSeconds = 40,
					ItemType = BuildItemTypeEnum.Building
				};

				bunker.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Barracks"));
				bunker.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Barracks", 1));

				bunker.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				bunker.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				bunker.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				bunker.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return bunker;
			}
		}

		private static BuildItemEntity Factory
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Factory",
					CostGas = 100,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 60,
					ItemType = BuildItemTypeEnum.Building
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Barracks"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Barracks", 1));

				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return item;
			}
		}

		private static BuildItemEntity Refinery
		{
			get
			{
				var refinery = new BuildItemEntity
				{
					Name = "Refinery",
					CostGas = 0,
					CostMinerals = 75,
					CostSupply = 0,
					BuildTimeInSeconds = 30,
					ItemType = BuildItemTypeEnum.Building
				};

				refinery.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));
                refinery.ProduceRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));

				refinery.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, -1));
				refinery.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				refinery.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				refinery.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				refinery.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));
				refinery.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, 3));

				return refinery;
			}
		}

		private static BuildItemEntity EngineeringBay
		{
			get
			{
				var eBay = new BuildItemEntity
				{
					Name = "EngineeringBay",
					CostGas = 0,
					CostMinerals = 125,
					CostSupply = 0,
					BuildTimeInSeconds = 35,
					ItemType = BuildItemTypeEnum.Building,
					DisplayName = "Engineering Bay"
				};

				eBay.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				eBay.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				eBay.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				eBay.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return eBay;
			}
		}

		private static BuildItemEntity GhostAcademy
		{
			get
			{
				var academy = new BuildItemEntity
				{
					Name = "GhostAcademy",
					CostGas = 50,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 40,
					ItemType = BuildItemTypeEnum.Building,
					DisplayName = "Ghost Academy"
				};

				academy.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Barracks"));
				academy.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Barracks", 1));

				academy.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				academy.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				academy.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				academy.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return academy;
			}
		}

		private static BuildItemEntity Starport
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Starport",
					CostGas = 100,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 50,
					ItemType = BuildItemTypeEnum.Building
				};


				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Factory"));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Factory", 1));

				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return item;
			}
		}

		private static BuildItemEntity Armory
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "Armory",
					CostGas = 100,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 65,
					ItemType = BuildItemTypeEnum.Building
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Factory"));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Factory", 1));

				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));
				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return item;
			}
		}

		private static BuildItemEntity FusionCore
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "FusionCore",
					DisplayName = "Fusion Core",
					CostGas = 150,
					CostMinerals = 150,
					CostSupply = 0,
					BuildTimeInSeconds = 65,
					ItemType = BuildItemTypeEnum.Building
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Starport"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Starport", 1));

				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));

				return item;
			}
		}

		private static BuildItemEntity TechLabOnBarracks
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "TechLabOnBarracks",
					DisplayName = "Lab on Barracks",
					CostGas = 25,
					CostMinerals = 50,
					CostSupply = 0,
					BuildTimeInSeconds = 25,
					ItemType = BuildItemTypeEnum.Building,
					ProductionBuildingName = "Barracks"
				};

				item.OrderRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Barracks", "Barracks" + Consts.BuildItemOnBuildingPostfix },
								new[] { "TechLabOnBarracks", "TechLabOnBarracks" + Consts.BuildItemOnBuildingPostfix, "ReactorOnBarracks", "ReactorOnBarracks" + Consts.BuildItemOnBuildingPostfix }));

				item.ProduceRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Barracks" },
								new[] { "TechLabOnBarracks", "TechLabOnBarracks" + Consts.BuildItemOnBuildingPostfix, "ReactorOnBarracks", "ReactorOnBarracks" + Consts.BuildItemOnBuildingPostfix }));

				return item;
			}
		}

		private static BuildItemEntity ReactorOnBarracks
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "ReactorOnBarracks",
					DisplayName = "Reactor on Barracks",
					CostGas = 50,
					CostMinerals = 50,
					CostSupply = 0,
					BuildTimeInSeconds = 50,
					ItemType = BuildItemTypeEnum.Building,
					ProductionBuildingName = "Barracks"
				};

				item.OrderRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Barracks", "Barracks" + Consts.BuildItemOnBuildingPostfix },
								new[] { "TechLabOnBarracks", "TechLabOnBarracks" + Consts.BuildItemOnBuildingPostfix, "ReactorOnBarracks", "ReactorOnBarracks" + Consts.BuildItemOnBuildingPostfix }));

				item.ProduceRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Barracks" },
								new[] { "TechLabOnBarracks", "TechLabOnBarracks" + Consts.BuildItemOnBuildingPostfix, "ReactorOnBarracks", "ReactorOnBarracks" + Consts.BuildItemOnBuildingPostfix }));

				return item;
			}
		}

		private static BuildItemEntity TechLabOnFactory
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "TechLabOnFactory",
					DisplayName = "Lab on Factory",
					CostGas = 25,
					CostMinerals = 50,
					CostSupply = 0,
					BuildTimeInSeconds = 25,
					ItemType = BuildItemTypeEnum.Building,
					ProductionBuildingName = "Factory"
				};

				item.OrderRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Factory", "Factory" + Consts.BuildItemOnBuildingPostfix },
								new[] { "TechLabOnFactory", "TechLabOnFactory" + Consts.BuildItemOnBuildingPostfix, 
                            "ReactorOnFactory", "ReactorOnFactory" + Consts.BuildItemOnBuildingPostfix }));

				item.ProduceRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Factory" },
								new[] { "TechLabOnFactory", "TechLabOnFactory" + Consts.BuildItemOnBuildingPostfix, 
                            "ReactorOnFactory", "ReactorOnFactory" + Consts.BuildItemOnBuildingPostfix }));

				return item;
			}
		}

		private static BuildItemEntity ReactorOnFactory
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "ReactorOnFactory",
					DisplayName = "Reactor on Factory",
					CostGas = 50,
					CostMinerals = 50,
					CostSupply = 0,
					BuildTimeInSeconds = 50,
					ItemType = BuildItemTypeEnum.Building,
					ProductionBuildingName = "Factory"
				};

				item.OrderRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Factory", "Factory" + Consts.BuildItemOnBuildingPostfix },
								new[] { "TechLabOnFactory", "TechLabOnFactory" + Consts.BuildItemOnBuildingPostfix, 
                            "ReactorOnFactory", "ReactorOnFactory" + Consts.BuildItemOnBuildingPostfix }));

				item.ProduceRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Factory" },
								new[] { "TechLabOnFactory", "TechLabOnFactory" + Consts.BuildItemOnBuildingPostfix, 
                            "ReactorOnFactory", "ReactorOnFactory" + Consts.BuildItemOnBuildingPostfix }));

				return item;
			}
		}

		private static BuildItemEntity TechLabOnStarport
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "TechLabOnStarport",
					DisplayName = "Lab on Starport",
					CostGas = 25,
					CostMinerals = 50,
					CostSupply = 0,
					BuildTimeInSeconds = 25,
					ItemType = BuildItemTypeEnum.Building,
					ProductionBuildingName = "Starport"
				};

				item.OrderRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Starport", "Starport" + Consts.BuildItemOnBuildingPostfix },
								new[] { "TechLabOnStarport", "TechLabOnStarport" + Consts.BuildItemOnBuildingPostfix,
                        "ReactorOnStarport", "ReactorOnStarport" + Consts.BuildItemOnBuildingPostfix}));

				item.ProduceRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Starport" },
								new[] { "TechLabOnStarport", "TechLabOnStarport" + Consts.BuildItemOnBuildingPostfix,
                        "ReactorOnStarport", "ReactorOnStarport" + Consts.BuildItemOnBuildingPostfix}));

				return item;
			}
		}

		private static BuildItemEntity ReactorOnStarport
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "ReactorOnStarport",
					DisplayName = "Reactor on Starport",
					CostGas = 50,
					CostMinerals = 50,
					CostSupply = 0,
					BuildTimeInSeconds = 50,
					ItemType = BuildItemTypeEnum.Building,
					ProductionBuildingName = "Starport"
				};

				item.OrderRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Starport", "Starport" + Consts.BuildItemOnBuildingPostfix },
								new[] { "TechLabOnStarport", "TechLabOnStarport" + Consts.BuildItemOnBuildingPostfix,
                        "ReactorOnStarport", "ReactorOnStarport" + Consts.BuildItemOnBuildingPostfix}));

				item.ProduceRequirements.Add(
						new StatsAdditionIsBiggerThenStatsAdditionRequirement(
								new[] { "Starport" },
								new[] { "TechLabOnStarport", "TechLabOnStarport" + Consts.BuildItemOnBuildingPostfix,
                        "ReactorOnStarport", "ReactorOnStarport" + Consts.BuildItemOnBuildingPostfix}));

				return item;
			}
		}

		private static BuildItemEntity SensorTower
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "SensorTower",
					CostGas = 100,
					CostMinerals = 125,
					CostSupply = 0,
					BuildTimeInSeconds = 25,
					ItemType = BuildItemTypeEnum.Building,
					DisplayName = "Sensor Tower"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("EngineeringBay"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("EngineeringBay", 1));

				return item;
			}
		}

		private static BuildItemEntity MissileTurret
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "MissileTurret",
					CostGas = 0,
					CostMinerals = 100,
					CostSupply = 0,
					BuildTimeInSeconds = 25,
					ItemType = BuildItemTypeEnum.Building,
					DisplayName = "Missle Turret"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("EngineeringBay"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("EngineeringBay", 1));

				return item;
			}
		}

		#endregion

		#region Special

		private static BuildItemEntity CallMule
		{
			get
			{
				var mule = new BuildItemEntity
				{
					Name = "CallMule",
					CostGas = 0,
					CostMinerals = 0,
					CostSupply = 0,
					BuildTimeInSeconds = 90,
					ItemType = BuildItemTypeEnum.Special,
					DisplayName = "Call Mule"
				};

				mule.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("OrbitalCommand"));

				mule.ProduceRequirements.Add(new CastRequirement(1));

				mule.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MulesOnMinerals, 1));
				mule.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MulesOnMinerals, -1));

				return mule;
			}
		}

		private static BuildItemEntity GasScv
		{
			get
			{
				var gasScv = new BuildItemEntity
				{
					Name = "GasScv",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 4,
					DisplayName = "SCV on Gas"
				};

				gasScv.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 0));

				gasScv.OrderRequirements.Add(new OrBuildItemRequirement(
						new StatBiggerOrEqualThenValueRequirement("Refinery" + Consts.BuildItemOnBuildingPostfix, 1),
						new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.GasSpace, 1)));

				gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
				gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Refinery", 1));
				gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.GasSpace, 1));

				gasScv.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				gasScv.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, -1));

                gasScv.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnGas, 1));

				return gasScv;
			}
		}

		private static BuildItemEntity MineralScv
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "MineralScv",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 4,
					DisplayName = "SCV on Minerals"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1));

				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnGas, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, 1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

				return item;
			}
		}

		private static BuildItemEntity SalvageBunker
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "SalvageBunker",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					DisplayName = "Salvage Bunker"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Bunker", 1));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Bunker", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("Bunker", -1));

				item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.Minerals, 100));

				return item;
			}
		}

		private static BuildItemEntity CallSupplyDrop
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "CallSupplyDrop",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					DisplayName = "Call Supply Drop"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("OrbitalCommand"));

				item.OrderRequirements.Add(new OrBuildItemRequirement(
						new StatLessThenStatRequirement("CallSupplyDrop", "SupplyDepot"),
						new StatBiggerOrEqualThenValueRequirement("SupplyDepot" + Consts.BuildItemOnBuildingPostfix, 1)));

				item.ProduceRequirements.Add(new CastRequirement(1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("CallSupplyDrop", "SupplyDepot"));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 8));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 8, "MaximumSupplyLimit"));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -8));

				return item;
			}
		}

		private static BuildItemEntity GoOutScv
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "GoOutScv",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					DisplayName = "Scout SCV"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

				return item;
			}
		}

		private static BuildItemEntity ReturnScv
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "ReturnScv",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					DisplayName = "Return Scout"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnWalk, 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnWalk, 1));

				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, -1));
				item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

				return item;
			}
		}

		private static BuildItemEntity ScannerSweep
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "ScannerSweep",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					DisplayName = "Scanner Sweep"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("OrbitalCommand"));
				item.ProduceRequirements.Add(new CastRequirement(1));

				return item;
			}
		}

		private static BuildItemEntity LiftRaxFromTechLab
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LiftRaxFromTechLab",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					ProductionBuildingName = "Barracks",
					DisplayName = "Lift Barracks from Lab"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnBarracks"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnBarracks", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnBarracks" + Consts.BuzyBuildItemPostfix, "TechLabOnBarracks"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnBarracks", -1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeTechLab", 1));

				return item;
			}
		}

		private static BuildItemEntity LandRaxOnTechLab
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LandRaxOnTechLab",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					ProductionBuildingName = "Barracks",
					DisplayName = "Land Barracks on Lab"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeTechLab", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeTechLab", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnBarracks", 1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeTechLab", -1));

				return item;
			}
		}

        private static BuildItemEntity StartIdle
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = IdleModule.StartIdle,
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Start Idle",
                    BuildTimeInSeconds = 0
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement(IdleModule.StartIdle, 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement(IdleModule.StartIdle + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, 1));

                return item;
            }
        }

        private static BuildItemEntity StopIdleIn3Seconds
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "StopIdleIn3Seconds",
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Stop Idle in 3 seconds",
                    BuildTimeInSeconds = 0
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 3));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle + Consts.BuildItemOnBuildingPostfix, -1));
                
                return item;
            }
        }

        private static BuildItemEntity StopIdleIn5Seconds
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "StopIdleIn5Seconds",
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Stop Idle in 5 seconds",
                    BuildTimeInSeconds = 0
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 5));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle + Consts.BuildItemOnBuildingPostfix, -1));

                return item;
            }
        }

        private static BuildItemEntity StopIdleIn10Seconds
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "StopIdleIn10Seconds",
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Stop Idle in 10 seconds",
                    BuildTimeInSeconds = 0
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 10));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle + Consts.BuildItemOnBuildingPostfix, -1));

                return item;
            }
        }

		private static BuildItemEntity LiftRaxFromReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LiftRaxFromReactor",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					ProductionBuildingName = "Barracks",
					DisplayName = "Lift Barracks from Reactor"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnBarracks"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnBarracks", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnBarracks" + Consts.BuzyBuildItemPostfix, "ReactorOnBarracks"));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnBarracks", -1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeReactor", 1));

				return item;
			}
		}

		private static BuildItemEntity LandRaxOnReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LandRaxOnReactor",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					ProductionBuildingName = "Barracks",
					DisplayName = "Land Barracks on Reactor"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeReactor", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeReactor", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnBarracks", 1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeReactor", -1));

				return item;
			}
		}

		private static BuildItemEntity LiftFactoryFromTechLab
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LiftFactoryFromTechLab",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					ProductionBuildingName = "Factory",
					DisplayName = "Lift Factory from Lab"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnFactory"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnFactory", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnFactory" + Consts.BuzyBuildItemPostfix, "TechLabOnFactory"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnFactory", -1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeTechLab", 1));

				return item;
			}
		}

		private static BuildItemEntity LandFactoryOnTechLab
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LandFactoryOnTechLab",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					ProductionBuildingName = "Factory",
					DisplayName = "Land Factory on Lab"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeTechLab", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeTechLab", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnFactory", 1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeTechLab", -1));

				return item;
			}
		}

		private static BuildItemEntity LiftFactoryFromReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LiftFactoryFromReactor",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					ProductionBuildingName = "Factory",
					DisplayName = "Lift Factory from Reactor"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnFactory"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnFactory", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnFactory" + Consts.BuzyBuildItemPostfix, "ReactorOnFactory"));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnFactory", -1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeReactor", 1));

				return item;
			}
		}

		private static BuildItemEntity LandFactoryOnReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LandFactoryOnReactor",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					ProductionBuildingName = "Factory",
					DisplayName = "Land Factory on Reactor"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeReactor", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeReactor", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnFactory", 1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeReactor", -1));

				return item;
			}
		}

		private static BuildItemEntity LiftStarportFromTechLab
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LiftStarportFromTechLab",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					ProductionBuildingName = "Starport",
					DisplayName = "Lift Starport from Lab"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TechLabOnStarport"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TechLabOnStarport", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("TechLabOnStarport" + Consts.BuzyBuildItemPostfix, "TechLabOnStarport"));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnStarport", -1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeTechLab", 1));

				return item;
			}
		}

		private static BuildItemEntity LandStarportOnTechLab
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LandStarportOnTechLab",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					ProductionBuildingName = "Starport",
					DisplayName = "Land Starport on Lab"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeTechLab", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeTechLab", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("TechLabOnStarport", 1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeTechLab", -1));

				return item;
			}
		}

		private static BuildItemEntity LiftStarportFromReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LiftStarportFromReactor",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 3,
					ProductionBuildingName = "Starport",
					DisplayName = "Lift Starport from Reactor"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ReactorOnStarport"));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ReactorOnStarport", 1));
				item.ProduceRequirements.Add(new StatLessThenStatRequirement("ReactorOnStarport" + Consts.BuzyBuildItemPostfix, "ReactorOnStarport"));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnStarport", -1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeReactor", 1));

				return item;
			}
		}

		private static BuildItemEntity LandStarportOnReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "LandStarportOnReactor",
					ItemType = BuildItemTypeEnum.Special,
					BuildTimeInSeconds = 1,
					ProductionBuildingName = "Starport",
					DisplayName = "Land Starport on Reactor"
				};

				item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeReactor", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeReactor", 1));

				item.OrderedActions.Add(new ChangeStatisticAction("ReactorOnStarport", 1));
				item.OrderedActions.Add(new ChangeStatisticAction("FreeReactor", -1));

				return item;
			}
		}

		#endregion

		#region Upgrades

		private static BuildItemEntity InfantryWeaponsLevel1
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfantryWeaponsLevel1",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 160,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Infantry Weapons Level 1"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel1", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel1", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity InfantryWeaponsLevel2
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfantryWeaponsLevel2",
					CostMinerals = 175,
					CostGas = 175,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 190,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Infantry Weapons Level 2"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("InfantryWeaponsLevel1"));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel2", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("InfantryWeaponsLevel1", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel2", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity InfantryWeaponsLevel3
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfantryWeaponsLevel3",
					CostMinerals = 250,
					CostGas = 250,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 220,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Infantry Weapons Level 3"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("InfantryWeaponsLevel2"));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel3", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("InfantryWeaponsLevel2", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel3", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity InfantryArmorLevel1
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfantryArmorLevel1",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 160,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Infantry Armor Level 1"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel1", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel1", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity InfantryArmorLevel2
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfantryArmorLevel2",
					CostMinerals = 175,
					CostGas = 175,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 190,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Infantry Armor Level 2"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("InfantryArmorLevel1"));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel2", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("InfantryArmorLevel1", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel2", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity InfantryArmorLevel3
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfantryArmorLevel3",
					CostMinerals = 250,
					CostGas = 250,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 220,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Infantry Armor Level 3"
				};

				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));
				item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("InfantryArmorLevel2"));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel3", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));
				item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("InfantryArmorLevel2", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel3", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfantryArmorLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity VehicleAndShipWeaponsLevel1
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "VehicleAndShipWeaponsLevel1",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 160,
					ProductionBuildingName = "Armory",
					DisplayName = "Vehicle and Ship Weapons Level 1"
				};

                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

        private static BuildItemEntity VehicleAndShipWeaponsLevel2
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "VehicleAndShipWeaponsLevel2",
					CostMinerals = 175,
					CostGas = 175,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 190,
					ProductionBuildingName = "Armory",
					DisplayName = "Vehicle and Ship Weapons Level 2"
				};

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("VehicleAndShipWeaponsLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("VehicleAndShipWeaponsLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

        private static BuildItemEntity VehicleAndShipWeaponsLevel3
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "VehicleAndShipWeaponsLevel3",
					CostMinerals = 250,
					CostGas = 250,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 220,
					ProductionBuildingName = "Armory",
					DisplayName = "Vehicle and Ship Weapons Level 3"
				};

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("VehicleAndShipWeaponsLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("VehicleAndShipWeaponsLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity VehicleAndShipPlatingLevel1
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "VehicleAndShipPlatingLevel1",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 160,
					ProductionBuildingName = "Armory",
					DisplayName = "Vehicle and Ship Plating Level 1"
				};

                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

        private static BuildItemEntity VehicleAndShipPlatingLevel2
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "VehicleAndShipPlatingLevel2",
					CostMinerals = 175,
					CostGas = 175,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 190,
					ProductionBuildingName = "Armory",
					DisplayName = "Vehicle and Ship Plating Level 2"
				};

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("VehicleAndShipPlatingLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("VehicleAndShipPlatingLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

        private static BuildItemEntity VehicleAndShipPlatingLevel3
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "VehicleAndShipPlatingLevel3",
					CostMinerals = 250,
					CostGas = 250,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 220,
					ProductionBuildingName = "Armory",
					DisplayName = "Vehicle and Ship Plating Level 3"
				};

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("VehicleAndShipPlatingLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("VehicleAndShipPlatingLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VehicleAndShipPlatingLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity StimPack
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "StimPack",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 170,
					ProductionBuildingName = "TechLabOnBarracks",
					DisplayName = "Stim Pack"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("StimPack", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("StimPack" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("StimPack", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("StimPack" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity CombatShield
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "CombatShield",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "TechLabOnBarracks",
					DisplayName = "Combat Shield"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("CombatShield", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("CombatShield" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CombatShield", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CombatShield" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity ConcussiveShells
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "ConcussiveShells",
					CostMinerals = 50,
					CostGas = 50,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 60,
					ProductionBuildingName = "TechLabOnBarracks",
					DisplayName = "Concussive Shells"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("ConcussiveShells", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("ConcussiveShells" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("ConcussiveShells", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("ConcussiveShells" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity InfernalPreIgniter
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "InfernalPreIgniter",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "TechLabOnFactory",
					DisplayName = "Infernal Pre-Igniter"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfernalPreIgniter", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("InfernalPreIgniter" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfernalPreIgniter", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("InfernalPreIgniter" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity DrillingClaws
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "DrillingClaws",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "TechLabOnFactory",
					DisplayName = "Drilling Claws"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("DrillingClaws", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("DrillingClaws" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Armory"));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("DrillingClaws", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("DrillingClaws" + Consts.BuildItemOnBuildingPostfix, 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Armory", 1));

				return item;
			}
		}

		private static BuildItemEntity CloakingField
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "CloakingField",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "TechLabOnStarport",
					DisplayName = "Cloaking Field"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("CloakingField", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("CloakingField" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CloakingField", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CloakingField" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity CaduceusReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "CaduceusReactor",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 80,
					ProductionBuildingName = "TechLabOnStarport",
					DisplayName = "Caduceus Reactor"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("CaduceusReactor", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("CaduceusReactor" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CaduceusReactor", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CaduceusReactor" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity CorvidReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "CorvidReactor",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "TechLabOnStarport",
					DisplayName = "Corvid Reactor"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("CorvidReactor", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("CorvidReactor" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CorvidReactor", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("CorvidReactor" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity DurableMaterials
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "DurableMaterials",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "TechLabOnStarport",
					DisplayName = "Durable Materials"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("DurableMaterials", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("DurableMaterials" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("DurableMaterials", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("DurableMaterials" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity HiSecAutoTracking
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "HiSecAutoTracking",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 80,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Hi Sec Auto Tracking"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("HiSecAutoTracking", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("HiSecAutoTracking" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("HiSecAutoTracking", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("HiSecAutoTracking" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity BuildingArmor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "BuildingArmor",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 140,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Building Armor"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("BuildingArmor", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("BuildingArmor" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("BuildingArmor", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("BuildingArmor" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity NeosteelFrame
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "NeosteelFrame",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 110,
					ProductionBuildingName = "EngineeringBay",
					DisplayName = "Neosteel Frame"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("NeosteelFrame", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("NeosteelFrame" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("NeosteelFrame", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("NeosteelFrame" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity Nuke
		{
			get
			{
				var item = new BuildItemEntity
				{
                    Name = "Nuke",
					CostMinerals = 100,
					CostGas = 100,
					ItemType = BuildItemTypeEnum.Unit,
					BuildTimeInSeconds = 60,
					ProductionBuildingName = "GhostAcademy",
					DisplayName = "Nuke Missile"
				};

				return item;
			}
		}

		private static BuildItemEntity PersonalCloaking
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "PersonalCloaking",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 120,
					ProductionBuildingName = "GhostAcademy",
					DisplayName = "Personal Cloaking"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("PersonalCloaking", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("PersonalCloaking" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("PersonalCloaking", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("PersonalCloaking" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity WeaponRefit
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "WeaponRefit",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 60,
					ProductionBuildingName = "FusionCore",
					DisplayName = "Weapon Refit"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("WeaponRefit", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("WeaponRefit" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("WeaponRefit", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("WeaponRefit" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		private static BuildItemEntity BehemothReactor
		{
			get
			{
				var item = new BuildItemEntity
				{
					Name = "BehemothReactor",
					CostMinerals = 150,
					CostGas = 150,
					ItemType = BuildItemTypeEnum.Upgrade,
					BuildTimeInSeconds = 80,
					ProductionBuildingName = "FusionCore",
					DisplayName = "Behemoth Reactor"
				};

				item.OrderRequirements.Add(new StatLessThenValueRequirement("BehemothReactor", 1));
				item.OrderRequirements.Add(new StatLessThenValueRequirement("BehemothReactor" + Consts.BuildItemOnBuildingPostfix, 1));

				item.ProduceRequirements.Add(new StatLessThenValueRequirement("BehemothReactor", 1));
				item.ProduceRequirements.Add(new StatLessThenValueRequirement("BehemothReactor" + Consts.BuildItemOnBuildingPostfix, 1));

				return item;
			}
		}

		#endregion
	}
}
