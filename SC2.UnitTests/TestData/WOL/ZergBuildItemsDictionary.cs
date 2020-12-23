using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Actions;
using SC2.Entities.BuildItems.Requirements;
using SC2.Entities.BuildOrderProcessor.Modules;

namespace SC2.UnitTests.TestData.WOL
{
    public static class ZergBuildItemsDictionary
    {
        public static BuildItemsDictionary GenerateBuildItemsDictionary()
        {
            var result = new BuildItemsDictionary();

            result.AddItem(DefaultItem);

            result.AddItem(Hatchery);
            result.AddItem(Lair);
            result.AddItem(Hive);
            result.AddItem(SpawningPool);
            result.AddItem(Extractor);
            result.AddItem(EvolutionChamber);
            result.AddItem(RoachWarren);
            result.AddItem(HydraliskDen);
            result.AddItem(SpineCrawler);
            result.AddItem(SporeCrawler);
            result.AddItem(BanelingNest);
            result.AddItem(InfestationPit);
            result.AddItem(Spire);
            result.AddItem(NydusNetwork);
            result.AddItem(UltraliskCavern);
            result.AddItem(GreaterSpire);
            result.AddItem(MacroHatchery);

            //UNITS
            result.AddItem(Drone);
            result.AddItem(Overlord);
            result.AddItem(Queen);
            result.AddItem(Zergling);

            result.AddItem(Roach);
            result.AddItem(Baneling);
            result.AddItem(Hydralisk);
            result.AddItem(Overseer);

            result.AddItem(Mutalisk);
            result.AddItem(Infestor);
            result.AddItem(Corruptor);
            result.AddItem(Ultralisk);

            result.AddItem(Broodlord);
            result.AddItem(NydusWorm);

            //SPECIAL
            result.AddItem(InjectLarva);
            result.AddItem(GasDrone);
            result.AddItem(MineralDrone);
            result.AddItem(GoOutDrone);

            result.AddItem(SpawnCreepTumor);
            result.AddItem(CancelExtractor);
            result.AddItem(ReturnDrone);
            result.AddItem(StartIdle);

            result.AddItem(StopIdleIn1Second);
            result.AddItem(StopIdleIn3Seconds);
            result.AddItem(StopIdleIn5Seconds);
            result.AddItem(StopIdleIn10Seconds);

            //UPGRADES
            result.AddItem(MetabolicBoost);
            result.AddItem(AdrenalineGlands);
            result.AddItem(GlialReconstitution);
            result.AddItem(TunnelingClaws);

            result.AddItem(Burrow);
            result.AddItem(PneumatizedCarapace);
            result.AddItem(VentralSacs);
            result.AddItem(CentrifugalHooks);

            result.AddItem(GroovedSpines);
            result.AddItem(NeuralParasite);
            result.AddItem(PathogenGlands);
            result.AddItem(ChitinousPlating);

            result.AddItem(MeleeAttacksLevel1);
            result.AddItem(MissleAttacksLevel1);

            result.AddItem(MeleeAtacksLevel2);
            result.AddItem(MeleeAttacksLevel3);
            result.AddItem(GroundCarapaceLevel1);
            result.AddItem(FlyerAttacksLevel1);

            result.AddItem(FlyerCarapaceLevel1);
            result.AddItem(MissleAttacksLevel2);
            result.AddItem(GroundCarapaceLevel2);
            result.AddItem(FlyerAttacksLevel2);

            result.AddItem(FlyerCarapaceLevel2);
            result.AddItem(MissleAttacksLevel3);
            result.AddItem(GroundCarapaceLevel3);
            result.AddItem(FlyerAttacksLevel3);
            
            result.AddItem(FlyerCarapaceLevel3);

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

                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Drone", 6));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("CurrentSupply", 6));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("MaximumSupply", 10));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("BasesCount", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Hatchery", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Minerals", 50));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("MaximumSupplyLimit", 200));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("TotalLarva", 3));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Hatchery1LarvaCount", 3));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Hatchery1LarvaTimer", 0));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("WorkersOnMinerals" + Consts.BuildItemOnBuildingPostfix, 6));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 2));

                defaultItem.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", 1));

                return defaultItem;
            }
        }

        #region Buildings

        private static BuildItemEntity Hatchery
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Hatchery",
                    CostGas = 0,
                    CostMinerals = 300,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 2));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser + Consts.BuildItemOnBuildingPostfix, 2));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 2, "MaximumSupplyLimit"));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BasesCount, 1));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -2));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser + Consts.BuildItemOnBuildingPostfix, -2));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 2));

                return item;
            }
        }

        private static BuildItemEntity MacroHatchery
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MacroHatchery",
                    CostGas = 0,
                    CostMinerals = 300,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    DisplayName = "Macro Hatchery",
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 2));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 2, "MaximumSupplyLimit"));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -2));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity Extractor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Extractor",
                    CostGas = 0,
                    CostMinerals = 25,
                    CostSupply = 0,
                    BuildTimeInSeconds = 30,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));
                item.ProduceRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, -1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, 3));

                return item;
            }
        }

        private static BuildItemEntity SpawningPool
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "SpawningPool",
                    CostGas = 0,
                    CostMinerals = 200,
                    CostSupply = 0,
                    BuildTimeInSeconds = 65,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Spawning Pool"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity EvolutionChamber
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "EvolutionChamber",
                    CostGas = 0,
                    CostMinerals = 75,
                    CostSupply = 0,
                    BuildTimeInSeconds = 35,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Evolution Chamber"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity RoachWarren
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "RoachWarren",
                    CostGas = 0,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 55,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Roach Warren"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SpawningPool"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SpawningPool", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity HydraliskDen
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "HydraliskDen",
                    CostGas = 100,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 40,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Hydralisk Den"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity SpineCrawler
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "SpineCrawler",
                    CostGas = 0,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Spine Crawler"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SpawningPool"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SpawningPool", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity SporeCrawler
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "SporeCrawler",
                    CostGas = 0,
                    CostMinerals = 75,
                    CostSupply = 0,
                    BuildTimeInSeconds = 30,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Spore Crawler"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("EvolutionChamber"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("EvolutionChamber", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity BanelingNest
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "BanelingNest",
                    CostGas = 50,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 60,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Baneling Nest"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SpawningPool"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SpawningPool", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity InfestationPit
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "InfestationPit",
                    CostGas = 100,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Infestation Pit"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity Spire
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Spire",
                    CostGas = 200,
                    CostMinerals = 200,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    ItemType = BuildItemTypeEnum.Building
                };
                
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForGraterSpire" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForGraterSpire" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForGraterSpire", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity NydusNetwork
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "NydusNetwork",
                    CostGas = 200,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Nydus Network"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity UltraliskCavern
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "UltraliskCavern",
                    CostGas = 200,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 65,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Ultralisk Cavern"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));

                return item;
            }
        }

        private static BuildItemEntity GreaterSpire
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GreaterSpire",
                    CostGas = 150,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    ItemType = BuildItemTypeEnum.Building,
                    ProductionBuildingName = "FreeSpireForGraterSpire",
                    DisplayName = "Greater Spire"
                };
                
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Spire"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Spire", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForGraterSpire", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity Lair
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Lair",
                    CostGas = 100,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 80,
                    ItemType = BuildItemTypeEnum.Building,
                    ProductionBuildingName = "FreeHatcheryForLair"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SpawningPool"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FreeHatcheryForMorph"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SpawningPool", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeHatcheryForMorph", 1));
                
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", -1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeLairForHive" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForLair", -1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeLairForHive" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeLairForHive", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity Hive
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Hive",
                    CostGas = 150,
                    CostMinerals = 200,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    ItemType = BuildItemTypeEnum.Building,
                    ProductionBuildingName = "FreeLairForHive"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("InfestationPit"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FreeHatcheryForMorph"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("InfestationPit", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeHatcheryForMorph", 1));
                
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", -1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeLairForHive", -1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForQueen", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForUpgrades", 1));

                return item;
            }
        }

        #endregion

        #region Units

        private static BuildItemEntity Drone
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Drone",
                    CostGas = 0,
                    CostMinerals = 50,
                    CostSupply = 1,
                    BuildTimeInSeconds = 17,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hatchery", 1));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

                return item;
            }
        }

        private static BuildItemEntity Overlord
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Overlord",
                    CostGas = 0,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 25,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hatchery", 1));
                item.ProduceRequirements.Add(new LarvaRequirement(1));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 8));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -8));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 8, "MaximumSupplyLimit"));

                return item;
            }
        }

        private static BuildItemEntity Queen
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Queen",
                    CostGas = 0,
                    CostMinerals = 150,
                    CostSupply = 2,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Unit,
                    ProductionBuildingName = "FreeHatcheryForQueen"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SpawningPool"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SpawningPool", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity Zergling
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Zergling",
                    CostGas = 0,
                    CostMinerals = 50,
                    CostSupply = 1,
                    BuildTimeInSeconds = 24,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hatchery"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("SpawningPool"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("SpawningPool", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("Zergling", 1));

                return item;
            }
        }

        private static BuildItemEntity Roach
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Roach",
                    CostGas = 25,
                    CostMinerals = 75,
                    CostSupply = 2,
                    BuildTimeInSeconds = 27,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("RoachWarren"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("RoachWarren", 1));

                return item;
            }
        }

        private static BuildItemEntity Hydralisk
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Hydralisk",
                    CostGas = 50,
                    CostMinerals = 100,
                    CostSupply = 2,
                    BuildTimeInSeconds = 33,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("HydraliskDen"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("HydraliskDen", 1));

                return item;
            }
        }

        private static BuildItemEntity Infestor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Infestor",
                    CostGas = 150,
                    CostMinerals = 100,
                    CostSupply = 2,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("InfestationPit"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("InfestationPit", 1));

                return item;
            }
        }

        private static BuildItemEntity Overseer
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Overseer",
                    CostGas = 50,
                    CostMinerals = 50,
                    BuildTimeInSeconds = 17,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Overlord", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Overlord", -1));

                return item;
            }
        }

        private static BuildItemEntity Mutalisk
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Mutalisk",
                    CostGas = 100,
                    CostMinerals = 100,
                    CostSupply = 2,
                    BuildTimeInSeconds = 33,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Spire"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Spire", 1));

                return item;
            }
        }

        private static BuildItemEntity Corruptor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Corruptor",
                    CostGas = 100,
                    CostMinerals = 150,
                    CostSupply = 2,
                    BuildTimeInSeconds = 40,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Spire"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Spire", 1));

                return item;
            }
        }

        private static BuildItemEntity Baneling
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Baneling",
                    CostGas = 25,
                    CostMinerals = 25,
                    BuildTimeInSeconds = 20,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Zergling"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("BanelingNest"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Zergling", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("BanelingNest", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Zergling", -1));

                return item;
            }
        }

        private static BuildItemEntity Ultralisk
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Ultralisk",
                    CostGas = 200,
                    CostMinerals = 300,
                    CostSupply = 6,
                    BuildTimeInSeconds = 55,
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("UltraliskCavern"));

                item.ProduceRequirements.Add(new LarvaRequirement(1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("UltraliskCavern", 1));

                return item;
            }
        }

        private static BuildItemEntity Broodlord
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Broodlord",
                    CostGas = 150,
                    CostMinerals = 150,
                    BuildTimeInSeconds = 34,
                    ItemType = BuildItemTypeEnum.Unit,
                    CostSupply = 2
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Corruptor"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GreaterSpire"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GreaterSpire", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Corruptor", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Corruptor", -1));

                return item;
            }
        }

        private static BuildItemEntity NydusWorm
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "NydusWorm",
                    CostGas = 100,
                    CostMinerals = 100,
                    BuildTimeInSeconds = 20,
                    ItemType = BuildItemTypeEnum.Unit,
                    CostSupply = 0,
                    DisplayName = "Nydus Worm",
                    ProductionBuildingName = "NydusNetwork"
                };

                return item;
            }
        }

        #endregion

        #region Specials

        private static BuildItemEntity StartIdle
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "StartIdle",
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Start Idle",
                    BuildTimeInSeconds = 1
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement(IdleModule.StartIdle, 1));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, 1));

                return item;
            }
        }

        private static BuildItemEntity StopIdleIn1Second
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "StopIdleIn1Second",
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Stop Idle in 1 second",
                    BuildTimeInSeconds = 1
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 1));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));

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
                    BuildTimeInSeconds = 1
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 3));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));

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
                    BuildTimeInSeconds = 1
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 5));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));

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
                    BuildTimeInSeconds = 1
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(IdleModule.StartIdle));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(IdleModule.IdleTimer, 10));

                item.OrderedActions.Add(new ChangeStatisticAction(IdleModule.StartIdle, -1));

                return item;
            }
        }

        private static BuildItemEntity GasDrone
        {
            get
            {
                var gasScv = new BuildItemEntity
                {
                    Name = "GasDrone",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 4,
                    DisplayName = "Drone to Gas"
                };

                gasScv.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 0));

                gasScv.OrderRequirements.Add(new OrBuildItemRequirement(
                        new StatBiggerOrEqualThenValueRequirement("Extractor" + Consts.BuildItemOnBuildingPostfix, 1),
                        new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.GasSpace, 1)));

                gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
                gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Extractor", 1));
                gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.GasSpace, 1));

                gasScv.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                gasScv.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, -1));

                gasScv.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnGas, 1));

                return gasScv;
            }
        }

        private static BuildItemEntity MineralDrone
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MineralDrone",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 4,
                    DisplayName = "Drone to Minerals"
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnGas, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, 1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

                return item;
            }
        }

        private static BuildItemEntity GoOutDrone
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GoOutDrone",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 1,
                    DisplayName = "Scout Drone"
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

                return item;
            }
        }

        private static BuildItemEntity ReturnDrone
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ReturnDrone",
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

        private static BuildItemEntity InjectLarva
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "InjectLarva",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 40,
                    ProductionBuildingName = "Hatchery",
                    DisplayName = "Inject Larva"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Queen"));
                item.ProduceRequirements.Add(new CastRequirement(1));

                return item;
            }
        }

        private static BuildItemEntity SpawnCreepTumor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "SpawnCreepTumor",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 1,
                    DisplayName = "Spawn Creep Tumor"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Queen"));
                item.ProduceRequirements.Add(new CastRequirement(1));

                return item;
            }
        }

        private static BuildItemEntity CancelExtractor
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "CancelExtractor",
                    CostGas = 0,
                    CostMinerals = 25,
                    CostSupply = 0,
                    BuildTimeInSeconds = 3,
                    DisplayName = "Extractor Trick",
                    ItemType = BuildItemTypeEnum.Special
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));
                item.ProduceRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Drone"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Drone", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.Minerals, 75));

                item.OrderedActions.Add(new ChangeStatisticAction("Drone", -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, -1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 1));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.CurrentSupply, 1));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));
                item.ProducedActions.Add(new ChangeStatisticAction("Drone", 1));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.Minerals, 19));

                return item;
            }
        }

        #endregion

        #region Upgrades

        private static BuildItemEntity MetabolicBoost
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MetabolicBoost",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "SpawningPool",
                    DisplayName = "Metabolic Boost"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("MetabolicBoost", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MetabolicBoost" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MetabolicBoost", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MetabolicBoost" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundCarapaceLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundCarapaceLevel1",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Ground Carapace Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity MissleAttacksLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MissleAttacksLevel1",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Missle Attacks Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity MeleeAttacksLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MeleeAttacksLevel1",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Melee Attacks Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity MeleeAtacksLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MeleeAtacksLevel2",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Melee Attacks Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("MeleeAttacksLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MeleeAtacksLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MeleeAtacksLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("MeleeAttacksLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MeleeAtacksLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MeleeAtacksLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundCarapaceLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundCarapaceLevel2",
                    CostMinerals = 225,
                    CostGas = 225,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Ground Carapace Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GroundCarapaceLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GroundCarapaceLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity MissleAttacksLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MissleAttacksLevel2",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Missle Attacks Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("MissleAttacksLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("MissleAttacksLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity MeleeAttacksLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MeleeAttacksLevel3",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Melee Attacks Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("MeleeAtacksLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("MeleeAtacksLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MeleeAttacksLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundCarapaceLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundCarapaceLevel3",
                    CostMinerals = 300,
                    CostGas = 300,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Ground Carapace Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GroundCarapaceLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GroundCarapaceLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundCarapaceLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity MissleAttacksLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MissleAttacksLevel3",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "EvolutionChamber",
                    DisplayName = "Missle Attacks Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("MissleAttacksLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("MissleAttacksLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("MissleAttacksLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity FlyerAttacksLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FlyerAttacksLevel1",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "FreeSpireForUpgrades",
                    DisplayName = "Flyer Attacks Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity FlyerAttacksLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FlyerAttacksLevel2",
                    CostMinerals = 175,
                    CostGas = 175,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "FreeSpireForUpgrades",
                    DisplayName = "Flyer Attacks Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FlyerAttacksLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FlyerAttacksLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity FlyerAttacksLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FlyerAttacksLevel3",
                    CostMinerals = 250,
                    CostGas = 250,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "FreeSpireForUpgrades",
                    DisplayName = "Flyer Attacks Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FlyerAttacksLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FlyerAttacksLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerAttacksLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity FlyerCarapaceLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FlyerCarapaceLevel1",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "FreeSpireForUpgrades",
                    DisplayName = "Flyer Carapace Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity FlyerCarapaceLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FlyerCarapaceLevel2",
                    CostMinerals = 225,
                    CostGas = 225,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "Spire",
                    DisplayName = "Flyer Carapace Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FlyerCarapaceLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FlyerCarapaceLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity FlyerCarapaceLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FlyerCarapaceLevel3",
                    CostMinerals = 300,
                    CostGas = 300,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "Spire",
                    DisplayName = "Flyer Carapace Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FlyerCarapaceLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FlyerCarapaceLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("FlyerCarapaceLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeSpireForUpgrades", 1));

                return item;
            }
        }

        private static BuildItemEntity Burrow
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Burrow",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 100,
                    ProductionBuildingName = "FreeHatcheryForUpgrades"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderRequirements.Add(new StatLessThenValueRequirement("Burrow", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("Burrow" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Burrow", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Burrow" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity PneumatizedCarapace
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "PneumatizedCarapace",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 60,
                    ProductionBuildingName = "FreeHatcheryForUpgrades",
                    DisplayName = "Pneumatized Carapace"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderRequirements.Add(new StatLessThenValueRequirement("PneumatizedCarapace", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("PneumatizedCarapace" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("PneumatizedCarapace", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("PneumatizedCarapace" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity VentralSacs
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "VentralSacs",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 130,
                    ProductionBuildingName = "FreeHatcheryForUpgrades",
                    DisplayName = "Ventral Sacs"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));

                item.OrderRequirements.Add(new StatLessThenValueRequirement("VentralSacs", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("VentralSacs" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VentralSacs", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("VentralSacs" + Consts.BuildItemOnBuildingPostfix, 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeHatcheryForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity GlialReconstitution
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GlialReconstitution",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "RoachWarren",
                    DisplayName = "Glial Reconstitution"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GlialReconstitution", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GlialReconstitution" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GlialReconstitution", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GlialReconstitution" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity TunnelingClaws
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "TunnelingClaws",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "RoachWarren",
                    DisplayName = "Tunneling Claws"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Lair"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("TunnelingClaws", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("TunnelingClaws" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Lair", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("TunnelingClaws", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("TunnelingClaws" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }


        private static BuildItemEntity CentrifugalHooks
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "CentrifugalHooks",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "BanelingNest",
                    DisplayName = "Centrifugal Hooks"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("CentrifugalHooks", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("CentrifugalHooks" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("CentrifugalHooks", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("CentrifugalHooks" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroovedSpines
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroovedSpines",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 80,
                    ProductionBuildingName = "HydraliskDen",
                    DisplayName = "Grooved Spines"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroovedSpines", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroovedSpines" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroovedSpines", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroovedSpines" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity NeuralParasite
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "NeuralParasite",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "InfestationPit",
                    DisplayName = "Neural Parasite"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("NeuralParasite", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("NeuralParasite" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("NeuralParasite", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("NeuralParasite" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity PathogenGlands
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "PathogenGlands",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 80,
                    ProductionBuildingName = "InfestationPit",
                    DisplayName = "Pathogen Glands"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("PathogenGlands", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("PathogenGlands" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("PathogenGlands", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("PathogenGlands" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AdrenalineGlands
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AdrenalineGlands",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 130,
                    ProductionBuildingName = "SpawningPool",
                    DisplayName = "Adrenaline Glands"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AdrenalineGlands", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AdrenalineGlands" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AdrenalineGlands", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AdrenalineGlands" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity ChitinousPlating
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ChitinousPlating",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "UltraliskCavern",
                    DisplayName = "Chitinous Plating"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Hive"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ChitinousPlating", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ChitinousPlating" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Hive", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ChitinousPlating", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ChitinousPlating" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        #endregion
    }
}
