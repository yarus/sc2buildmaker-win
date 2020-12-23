using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Actions;
using SC2.Entities.BuildItems.Requirements;
using SC2.Entities.BuildOrderProcessor.Modules;

namespace SC2.UnitTests.TestData.WOL
{
    public class ProtossBuildItemsDictionary
    {
        public static BuildItemsDictionary GenerateBuildItemsDictionary()
        {
            var result = new BuildItemsDictionary();

            //SPECIAL
            result.AddItem(DefaultItem);
            
            result.AddItem(Probe);
            result.AddItem(Zealot);
            result.AddItem(Stalker);
            result.AddItem(Sentry);

            result.AddItem(Observer);
            result.AddItem(WarpInZealot);
            result.AddItem(WarpInStalker);
            result.AddItem(WarpInSentry);

            result.AddItem(WarpPrism);
            result.AddItem(Immortal);
            result.AddItem(Colossus);
            result.AddItem(Phoenix);

            result.AddItem(VoidRay);
            result.AddItem(Carrier);
            result.AddItem(WarpInDarkTemplar);
            result.AddItem(WarpInHighTemplar);

            result.AddItem(ArchonFromTwoHT);
            result.AddItem(ArchonFromTwoDT);
            result.AddItem(ArchonFromOneHTandOneDT);
            result.AddItem(Mothership);

            result.AddItem(DarkTemplar);
            result.AddItem(HighTemplar);

            //BUILDINGS
            result.AddItem(Pylon);
            result.AddItem(Nexus);
            result.AddItem(Assimilator);
            result.AddItem(Gateway);
            result.AddItem(Forge);
            result.AddItem(CyberneticsCore);
            result.AddItem(PhotonCanon);
            result.AddItem(TwilightCouncil);
            result.AddItem(Stargate);
            result.AddItem(RoboticsFacility);
            result.AddItem(TemplarArchives);
            result.AddItem(FleetBeacon);
            result.AddItem(RoboticsBay);
            result.AddItem(DarkShrine);

            //UPGRADES
            result.AddItem(WarpgateUpgrade);
            result.AddItem(Hallucination);
            result.AddItem(Blink);
            result.AddItem(Charge);

            result.AddItem(ExtendedThermalLance);
            result.AddItem(PsionicStorm);
            result.AddItem(GroundWeaponsLevel1);
            result.AddItem(GroundArmorLevel1);

            result.AddItem(GroundWeaponsLevel2);
            result.AddItem(GroundArmorLevel2);
            result.AddItem(GroundWeaponsLevel3);
            result.AddItem(GroundArmorLevel3);

            result.AddItem(AirWeaponsLevel1);
            result.AddItem(AirArmorLevel1);
            result.AddItem(AirWeaponsLevel2);
            result.AddItem(AirArmorLevel2);

            result.AddItem(AirWeaponsLevel3);
            result.AddItem(AirArmorLevel3);
            result.AddItem(ShieldsLevel1);
            result.AddItem(ShieldsLevel2);

            result.AddItem(ShieldsLevel3);
            result.AddItem(GraviticDrive);
            result.AddItem(GraviticBoosters);
            result.AddItem(GravitonCatapult);

            //SPECIAL
            result.AddItem(Chronoboost);
            result.AddItem(GasProbe);
            result.AddItem(MineralProbe);
            result.AddItem(GoOutProbe);
            
            result.AddItem(SwitchToWarpgate);
            result.AddItem(SwitchToGateway);
            result.AddItem(ReturnProbe);
            result.AddItem(StartIdle);

            result.AddItem(StopIdleIn1Second);
            result.AddItem(StopIdleIn3Seconds);
            result.AddItem(StopIdleIn5Seconds);
            result.AddItem(StopIdleIn10Seconds);

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

                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Probe", 6));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("CurrentSupply", 6));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("MaximumSupply", 10));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("BasesCount", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Nexus", 1));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("Minerals", 50));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("MaximumSupplyLimit", 200));
                defaultItem.OrderedActions.Add(new ChangeStatisticAction("WorkersOnMinerals" + Consts.BuildItemOnBuildingPostfix, 6));

                defaultItem.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 2));

                return defaultItem;
            }
        }

        #region Units

        private static BuildItemEntity Probe
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Probe",
                    CostGas = 0,
                    CostMinerals = 50,
                    CostSupply = 1,
                    BuildTimeInSeconds = 17,
                    ProductionBuildingName = "Nexus",
                    ItemType = BuildItemTypeEnum.Unit
                };
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

                return item;
            }
        }

        private static BuildItemEntity Zealot
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Zealot",
                    CostGas = 0,
                    CostMinerals = 100,
                    CostSupply = 2,
                    BuildTimeInSeconds = 38,
                    ProductionBuildingName = "FreeGatewayForUnit",
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity Sentry
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Sentry",
                    CostGas = 100,
                    CostMinerals = 50,
                    CostSupply = 2,
                    BuildTimeInSeconds = 37,
                    ProductionBuildingName = "FreeGatewayForUnit",
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity Stalker
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Stalker",
                    CostGas = 50,
                    CostMinerals = 125,
                    CostSupply = 2,
                    BuildTimeInSeconds = 42,
                    ProductionBuildingName = "FreeGatewayForUnit",
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity DarkTemplar
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "DarkTemplar",
                    CostGas = 125,
                    CostMinerals = 125,
                    CostSupply = 2,
                    BuildTimeInSeconds = 55,
                    ProductionBuildingName = "FreeGatewayForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Dark Templar"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("DarkShrine"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("DarkShrine", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity HighTemplar
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "HighTemplar",
                    CostGas = 150,
                    CostMinerals = 50,
                    CostSupply = 2,
                    BuildTimeInSeconds = 55,
                    ProductionBuildingName = "FreeGatewayForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "High Templar"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TemplarArchives"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TemplarArchives", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity Observer
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Observer",
                    CostGas = 75,
                    CostMinerals = 25,
                    CostSupply = 1,
                    BuildTimeInSeconds = 40,
                    ProductionBuildingName = "RoboticsFacility",
                    ItemType = BuildItemTypeEnum.Unit
                };

                return item;
            }
        }

        private static BuildItemEntity WarpPrism
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpPrism",
                    CostGas = 0,
                    CostMinerals = 200,
                    CostSupply = 2,
                    BuildTimeInSeconds = 50,
                    ProductionBuildingName = "RoboticsFacility",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Warp Prism"
                };

                return item;
            }
        }

        private static BuildItemEntity Immortal
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Immortal",
                    CostGas = 100,
                    CostMinerals = 250,
                    CostSupply = 4,
                    BuildTimeInSeconds = 55,
                    ProductionBuildingName = "RoboticsFacility",
                    ItemType = BuildItemTypeEnum.Unit
                };

                return item;
            }
        }

        private static BuildItemEntity Colossus
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Colossus",
                    CostGas = 200,
                    CostMinerals = 300,
                    CostSupply = 6,
                    BuildTimeInSeconds = 75,
                    ProductionBuildingName = "RoboticsFacility",
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("RoboticsBay"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("RoboticsBay", 1));

                return item;
            }
        }

        private static BuildItemEntity Phoenix
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Phoenix",
                    CostGas = 100,
                    CostMinerals = 150,
                    CostSupply = 2,
                    BuildTimeInSeconds = 35,
                    ProductionBuildingName = "Stargate",
                    ItemType = BuildItemTypeEnum.Unit
                };

                return item;
            }
        }

        private static BuildItemEntity VoidRay
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "VoidRay",
                    CostGas = 150,
                    CostMinerals = 250,
                    CostSupply = 3,
                    BuildTimeInSeconds = 60,
                    ProductionBuildingName = "Stargate",
                    ItemType = BuildItemTypeEnum.Unit
                };

                return item;
            }
        }

        private static BuildItemEntity Carrier
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Carrier",
                    CostGas = 250,
                    CostMinerals = 350,
                    CostSupply = 6,
                    BuildTimeInSeconds = 120,
                    ProductionBuildingName = "Stargate",
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FleetBeacon"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FleetBeacon", 1));

                return item;
            }
        }

        private static BuildItemEntity Mothership
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Mothership",
                    CostGas = 400,
                    CostMinerals = 400,
                    CostSupply = 8,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "Nexus",
                    ItemType = BuildItemTypeEnum.Unit
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FleetBeacon"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FleetBeacon", 1));

                item.OrderRequirements.Add(new StatLessThenValueRequirement("Mothership", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("Mothership" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Mothership", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Mothership" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity ArchonFromTwoDT
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ArchonFromTwoDT",
                    BuildTimeInSeconds = 12,
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "2 DT to Archon"
                };

                item.OrderRequirements.Add(new OrBuildItemRequirement(
                    new StatBiggerOrEqualThenValueRequirement("DarkTemplar", 2),
                    new StatBiggerOrEqualThenValueRequirement("DarkTemplar" + Consts.BuildItemOnBuildingPostfix, 2)));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("DarkTemplar", 2));

                item.OrderedActions.Add(new ChangeStatisticAction("DarkTemplar", -2));
                item.ProducedActions.Add(new ChangeStatisticAction("Archon", 1));

                return item;
            }
        }

        private static BuildItemEntity ArchonFromTwoHT
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ArchonFromTwoHT",
                    BuildTimeInSeconds = 12,
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "2 HT to Archon"
                };

                item.OrderRequirements.Add(new OrBuildItemRequirement(
                    new StatBiggerOrEqualThenValueRequirement("HighTemplar", 2),
                    new StatBiggerOrEqualThenValueRequirement("HighTemplar" + Consts.BuildItemOnBuildingPostfix, 2)));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("HighTemplar", 2));

                item.OrderedActions.Add(new ChangeStatisticAction("HighTemplar", -2));
                item.ProducedActions.Add(new ChangeStatisticAction("Archon", 1));

                return item;
            }
        }

        private static BuildItemEntity ArchonFromOneHTandOneDT
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ArchonFromOneHTandOneDT",
                    BuildTimeInSeconds = 12,
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "DT + HT to Archon"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("DarkTemplar"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("HighTemplar"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("HighTemplar", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("DarkTemplar", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("HighTemplar", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("DarkTemplar", -1));

                item.ProducedActions.Add(new ChangeStatisticAction("Archon", 1));

                return item;
            }
        }

        private static BuildItemEntity WarpInZealot
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpInZealot",
                    CostGas = 0,
                    CostMinerals = 100,
                    CostSupply = 2,
                    BuildTimeInSeconds = 28,
                    ProductionBuildingName = "FreeWarpgateForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Warp in Zealot"
                };

                item.OrderedActions.Add(new ChangeStatisticAction("Zealot", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity WarpInSentry
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpInSentry",
                    CostGas = 100,
                    CostMinerals = 50,
                    CostSupply = 2,
                    BuildTimeInSeconds = 32,
                    ProductionBuildingName = "FreeWarpgateForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Warp in Sentry"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Sentry", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity WarpInStalker
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpInStalker",
                    CostGas = 50,
                    CostMinerals = 125,
                    CostSupply = 2,
                    BuildTimeInSeconds = 32,
                    ProductionBuildingName = "FreeWarpgateForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Warp in Stalker"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("Stalker", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity WarpInDarkTemplar
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpInDarkTemplar",
                    CostGas = 125,
                    CostMinerals = 125,
                    CostSupply = 2,
                    BuildTimeInSeconds = 45,
                    ProductionBuildingName = "FreeWarpgateForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Warp in Dark Templar"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("DarkShrine"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("DarkShrine", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("DarkTemplar", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity WarpInHighTemplar
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpInHighTemplar",
                    CostGas = 150,
                    CostMinerals = 50,
                    CostSupply = 2,
                    BuildTimeInSeconds = 45,
                    ProductionBuildingName = "FreeWarpgateForUnit",
                    ItemType = BuildItemTypeEnum.Unit,
                    DisplayName = "Warp in High Templar"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TemplarArchives"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TemplarArchives", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("HighTemplar", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", 1));

                return item;
            }
        }

        #endregion

        #region Buildings

        private static BuildItemEntity Pylon
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Pylon",
                    CostGas = 0,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 25,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 8));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 8, "MaximumSupplyLimit"));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -8));

                return item;
            }
        }

        private static BuildItemEntity Nexus
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Nexus",
                    CostGas = 0,
                    CostMinerals = 400,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, 10));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser + Consts.BuildItemOnBuildingPostfix, 2));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.MaximumSupply, 10, "MaximumSupplyLimit"));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BasesCount, 1));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.BuildingNewSupply, -10));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser + Consts.BuildItemOnBuildingPostfix, -2));
                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, 2));

                return item;
            }
        }

        private static BuildItemEntity Assimilator
        {
            get
            {
                var refinery = new BuildItemEntity
                {
                    Name = "Assimilator",
                    CostGas = 0,
                    CostMinerals = 75,
                    CostSupply = 0,
                    BuildTimeInSeconds = 30,
                    ItemType = BuildItemTypeEnum.Building
                };

                refinery.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));
                refinery.ProduceRequirements.Add(new ItemExistsOrOnBuildingRequirement(Consts.CoreStatistics.GasGayser));

                refinery.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasGayser, -1));

                refinery.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, 3));

                return refinery;
            }
        }

        private static BuildItemEntity Gateway
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Gateway",
                    CostGas = 0,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 65,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Pylon"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Pylon", 1));
                
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit", 1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));                

                return item;
            }
        }

        private static BuildItemEntity Forge
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Forge",
                    CostGas = 0,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 45,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Pylon"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Pylon", 1));

                return item;
            }
        }

        private static BuildItemEntity CyberneticsCore
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "CyberneticsCore",
                    CostGas = 0,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Cybernetics Core"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Gateway"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Gateway", 1));

                return item;
            }
        }

        private static BuildItemEntity PhotonCanon
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "PhotonCanon",
                    CostGas = 0,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 40,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Photon Canon"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Forge"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Forge", 1));

                return item;
            }
        }

        private static BuildItemEntity TwilightCouncil
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "TwilightCouncil",
                    CostGas = 100,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Twilight Council"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                return item;
            }
        }

        private static BuildItemEntity Stargate
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Stargate",
                    CostGas = 150,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 60,
                    ItemType = BuildItemTypeEnum.Building
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                return item;
            }
        }

        private static BuildItemEntity RoboticsFacility
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "RoboticsFacility",
                    CostGas = 100,
                    CostMinerals = 200,
                    CostSupply = 0,
                    BuildTimeInSeconds = 65,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Robotics Facility"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("CyberneticsCore"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("CyberneticsCore", 1));

                return item;
            }
        }

        private static BuildItemEntity TemplarArchives
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "TemplarArchives",
                    CostGas = 200,
                    CostMinerals = 150,
                    CostSupply = 0,
                    BuildTimeInSeconds = 50,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Templar Archives"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));

                return item;
            }
        }

        private static BuildItemEntity FleetBeacon
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "FleetBeacon",
                    CostGas = 200,
                    CostMinerals = 200,
                    CostSupply = 0,
                    BuildTimeInSeconds = 60,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Fleet Beacon"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("Stargate"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Stargate", 1));

                return item;
            }
        }

        private static BuildItemEntity RoboticsBay
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "RoboticsBay",
                    CostGas = 200,
                    CostMinerals = 200,
                    CostSupply = 0,
                    BuildTimeInSeconds = 65,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Robotics Bay"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("RoboticsFacility"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("RoboticsFacility", 1));

                return item;
            }
        }

        private static BuildItemEntity DarkShrine
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "DarkShrine",
                    CostGas = 250,
                    CostMinerals = 100,
                    CostSupply = 0,
                    BuildTimeInSeconds = 100,
                    ItemType = BuildItemTypeEnum.Building,
                    DisplayName = "Dark Shrine"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));

                return item;
            }
        }

        #endregion

        #region Upgrades

        private static BuildItemEntity WarpgateUpgrade
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "WarpgateUpgrade",
                    CostMinerals = 50,
                    CostGas = 50,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Warpgate"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("WarpgateUpgrade", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("WarpgateUpgrade" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("WarpgateUpgrade", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("WarpgateUpgrade" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity Hallucination
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Hallucination",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 80,
                    ProductionBuildingName = "CyberneticsCore"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("Hallucination", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("Hallucination" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Hallucination", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Hallucination" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity Blink
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Blink",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 140,
                    ProductionBuildingName = "TwilightCouncil"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("Blink", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("Blink" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Blink", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Blink" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity Charge
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Charge",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 140,
                    ProductionBuildingName = "TwilightCouncil"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("Charge", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("Charge" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Charge", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("Charge" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GraviticDrive
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GraviticDrive",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 80,
                    ProductionBuildingName = "RoboticsBay",
                    DisplayName = "Gravitic Drive"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GraviticDrive", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GraviticDrive" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GraviticDrive", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GraviticDrive" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GraviticBoosters
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GraviticBoosters",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 80,
                    ProductionBuildingName = "RoboticsBay",
                    DisplayName = "Gravitic Boosters"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GraviticBoosters", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GraviticBoosters" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GraviticBoosters", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GraviticBoosters" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity ExtendedThermalLance
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ExtendedThermalLance",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 140,
                    ProductionBuildingName = "RoboticsBay",
                    DisplayName = "Extended Thermal Lance"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("ExtendedThermalLance", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ExtendedThermalLance" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ExtendedThermalLance", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ExtendedThermalLance" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity PsionicStorm
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "PsionicStorm",
                    CostMinerals = 200,
                    CostGas = 200,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 110,
                    ProductionBuildingName = "TemplarArchives",
                    DisplayName = "Psionic Storm"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("PsionicStorm", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("PsionicStorm" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("PsionicStorm", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("PsionicStorm" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GravitonCatapult
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GravitonCatapult",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 80,
                    ProductionBuildingName = "FleetBeacon",
                    DisplayName = "Graviton Catapult"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GravitonCatapult", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GravitonCatapult" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GravitonCatapult", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GravitonCatapult" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundWeaponsLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundWeaponsLevel1",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Ground Weapons Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundWeaponsLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundWeaponsLevel2",
                    CostMinerals = 175,
                    CostGas = 175,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Ground Weapons Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GroundWeaponsLevel1"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GroundWeaponsLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundWeaponsLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundWeaponsLevel3",
                    CostMinerals = 250,
                    CostGas = 250,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Ground Weapons Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GroundWeaponsLevel2"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GroundWeaponsLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AirWeaponsLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AirWeaponsLevel1",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Air Weapons Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AirWeaponsLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AirWeaponsLevel2",
                    CostMinerals = 175,
                    CostGas = 175,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Air Weapons Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("AirWeaponsLevel1"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FleetBeacon"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("AirWeaponsLevel1", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FleetBeacon", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AirWeaponsLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AirWeaponsLevel3",
                    CostMinerals = 250,
                    CostGas = 250,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Air Weapons Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("AirWeaponsLevel2"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FleetBeacon"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("AirWeaponsLevel2", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FleetBeacon", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirWeaponsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundArmorLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundArmorLevel1",
                    CostMinerals = 100,
                    CostGas = 100,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Ground Armor Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundArmorLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundArmorLevel2",
                    CostMinerals = 175,
                    CostGas = 175,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Ground Armor Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GroundArmorLevel1"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GroundArmorLevel1", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity GroundArmorLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GroundArmorLevel3",
                    CostMinerals = 250,
                    CostGas = 250,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Ground Armor Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("GroundArmorLevel2"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("GroundArmorLevel2", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("GroundArmorLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AirArmorLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AirArmorLevel1",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Air Armor Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AirArmorLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AirArmorLevel2",
                    CostMinerals = 225,
                    CostGas = 225,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Air Armor Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("AirArmorLevel1"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FleetBeacon"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("AirArmorLevel1", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FleetBeacon", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity AirArmorLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "AirArmorLevel3",
                    CostMinerals = 300,
                    CostGas = 300,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "CyberneticsCore",
                    DisplayName = "Air Armor Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("AirArmorLevel2"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FleetBeacon"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("AirArmorLevel2", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FleetBeacon", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("AirArmorLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity ShieldsLevel1
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ShieldsLevel1",
                    CostMinerals = 150,
                    CostGas = 150,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 160,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Shields Level 1"
                };

                item.OrderRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel1", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel1", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel1" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity ShieldsLevel2
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ShieldsLevel2",
                    CostMinerals = 225,
                    CostGas = 225,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 190,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Shields Level 2"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ShieldsLevel1"));
                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel2", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ShieldsLevel1", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel2", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel2" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        private static BuildItemEntity ShieldsLevel3
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ShieldsLevel3",
                    CostMinerals = 300,
                    CostGas = 300,
                    ItemType = BuildItemTypeEnum.Upgrade,
                    BuildTimeInSeconds = 220,
                    ProductionBuildingName = "Forge",
                    DisplayName = "Shields Level 3"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("ShieldsLevel2"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("TwilightCouncil"));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel3", 1));
                item.OrderRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ShieldsLevel2", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("TwilightCouncil", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel3", 1));
                item.ProduceRequirements.Add(new StatLessThenValueRequirement("ShieldsLevel3" + Consts.BuildItemOnBuildingPostfix, 1));

                return item;
            }
        }

        #endregion

        #region Specials

        private static BuildItemEntity Chronoboost
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "Chronoboost",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 20
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ChronoboostAvailable", 1));
                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Nexus", 1));
                
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("ChronoboostAvailable", 1));

                return item;
            }
        }

        private static BuildItemEntity SwitchToWarpgate
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "SwitchToWarpgate",
                    CostGas = 0,
                    CostMinerals = 0,
                    CostSupply = 0,
                    BuildTimeInSeconds = 10,
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Switch to Warpgate"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("WarpgateUpgrade"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FreeGatewayForMorph"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeGatewayForMorph", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("WarpgateUpgrade", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit", -1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForUnit" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForUnit" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForUnit", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity SwitchToGateway
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "SwitchToGateway",
                    CostGas = 0,
                    CostMinerals = 0,
                    CostSupply = 0,
                    BuildTimeInSeconds = 10,
                    ItemType = BuildItemTypeEnum.Special,
                    DisplayName = "Switch to Gateway"
                };

                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("WarpgateUpgrade"));
                item.OrderRequirements.Add(new ItemExistsOrOnBuildingRequirement("FreeWarpgateForMorph"));

                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("FreeWarpgateForMorph", 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("WarpgateUpgrade", 1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForMorph", -1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeWarpgateForUnit", -1));

                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit" + Consts.BuildItemOnBuildingPostfix, 1));
                item.OrderedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForUnit", 1));

                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph" + Consts.BuildItemOnBuildingPostfix, -1));
                item.ProducedActions.Add(new ChangeStatisticAction("FreeGatewayForMorph", 1));

                return item;
            }
        }

        private static BuildItemEntity GasProbe
        {
            get
            {
                var gasScv = new BuildItemEntity
                {
                    Name = "GasProbe",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 4,
                    DisplayName = "Probe to Gas"
                };

                gasScv.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 0));

                gasScv.OrderRequirements.Add(new OrBuildItemRequirement(
                        new StatBiggerOrEqualThenValueRequirement("Assimilator" + Consts.BuildItemOnBuildingPostfix, 1),
                        new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.GasSpace, 1)));

                gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
                gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement("Assimilator", 1));
                gasScv.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.GasSpace, 1));

                gasScv.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                gasScv.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, -1));

                gasScv.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnGas, 1));

                return gasScv;
            }
        }

        private static BuildItemEntity MineralProbe
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "MineralProbe",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 4,
                    DisplayName = "Probe to Minerals"
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnGas, 1));

                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnGas, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.GasSpace, 1));

                item.ProducedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, 1));

                return item;
            }
        }

        private static BuildItemEntity GoOutProbe
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "GoOutProbe",
                    ItemType = BuildItemTypeEnum.Special,
                    BuildTimeInSeconds = 1,
                    DisplayName = "Scout Probe"
                };

                item.OrderRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
                item.ProduceRequirements.Add(new StatBiggerOrEqualThenValueRequirement(Consts.CoreStatistics.WorkersOnMinerals, 1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnMinerals, -1));
                item.OrderedActions.Add(new ChangeStatisticAction(Consts.CoreStatistics.WorkersOnWalk, 1));

                return item;
            }
        }

        private static BuildItemEntity ReturnProbe
        {
            get
            {
                var item = new BuildItemEntity
                {
                    Name = "ReturnProbe",
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

        #endregion
    }
}
