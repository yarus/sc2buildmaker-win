using System.Collections.Generic;
using SC2.DataAccess;
using SC2.DataAccess.FileStorage;
using SC2.DataManagers;
using SC2.Entities;
using SC2.PublicData;

namespace SC2.UnitTests.TestData.WOL
{
    public class TestBuildOrdersManager : IBuildOrdersManager
	{
		private readonly IBuildOrdersDataAccess mDataAccess;

		private readonly Dictionary<string, BuildOrderEntity> mBuildEntities;

		public TestBuildOrdersManager()
		{
			this.mDataAccess = new BuildOrdersDataAccess(new JsonStorageDataAccess());

			this.mBuildEntities = new Dictionary<string, BuildOrderEntity>();
		}

		public IEnumerable<BuildOrderEntity> GetBuildOrders()
		{
			if (this.mBuildEntities.Values.Count == 0)
			{
				var terranBuild = InfoEntityConverter.Convert(Construct111Build());
				var protossBuild = InfoEntityConverter.Convert(ConstructKcdc1GateFEvsTerran());
				var zergBuild = InfoEntityConverter.Convert(ConstructSpeedlingExpandBuild());

				this.mBuildEntities.Add(terranBuild.Name, terranBuild);
				this.mBuildEntities.Add(protossBuild.Name, protossBuild);
				this.mBuildEntities.Add(zergBuild.Name, zergBuild);
			}

			return this.mBuildEntities.Values;
		}

		public BuildOrderEntity GetBuildOrder(string name)
		{
			if (!this.mBuildEntities.ContainsKey(name))
			{
				this.GetBuildOrders();
			}

			return this.mBuildEntities[name];
		}

		public void SaveBuildOrder(BuildOrderEntity entity)
		{
			var boInfo = InfoEntityConverter.Convert(entity);

			this.mDataAccess.SaveBuildOrder(boInfo);

			this.mBuildEntities[entity.Name] = entity;
		}

		#region TestBuilds

		private static BuildOrderInfo ConstructKcdc1GateFEvsTerran()
		{
			var bo = new BuildOrderInfo()
			{
				Name = "Kcdc 1 Gate FE vs Terran",
				Description = "Cool protoss build order",
				Race = "Protoss",
				VsRace = "Terran",
				SC2VersionID = "2.0.5",
				AddonID = "WOL"
			};

			bo.BuildOrderItems = new List<string>
            {
                "Probe",
                "Probe",
                "Probe",
                "Pylon",
                "Probe",
                "Probe",
                "Chronoboost",
                "Probe",
                "Chronoboost",
                "Probe",
                "Gateway",
                "Probe",
                "Probe",
                "Chronoboost",
                "Assimilator",
                "Probe",
                "Pylon",
                "Probe",
                "GasProbe",
                "GasProbe",
                "GasProbe",
                "Probe",
                "CyberneticsCore",
                "Probe",
                "Zealot",
                "Probe",
                "Pylon",
                "Probe",
                "Stalker",
                "WarpgateUpgrade",
                "Chronoboost",
                "Chronoboost",
                "Chronoboost",
                "Chronoboost",
                "Probe",
                "Probe",
                "Nexus",
                "Probe",
                "Gateway",
                "Probe",
                "Sentry",
                "Pylon",
                "Probe",
                "Forge",
                "Probe",
                "Zealot",
                "Assimilator",
                "Assimilator",
                "Probe",
                "Pylon",
                "SwitchToWarpgate"
            };

			return bo;
		}

		private static BuildOrderInfo Construct111Build()
		{
			var bo = new BuildOrderInfo
			{
				Name = "1-1-1 Opener",
				Description = "Safe terran build order",
				Race = "Terran",
				VsRace = "NotDefined",
				SC2VersionID = "2.0.5",
				AddonID = "WOL"
			};

			bo.BuildOrderItems = new List<string>
            {
                "SCV",
                "SCV",
                "SCV",
                "SCV",
                "SupplyDepot",
                "SCV",
                "SCV",
                "Barracks",
                "SCV",
                "Refinery",
                "SCV",
                "SCV",
                "GasScv",
                "GasScv",
                "GasScv",
                "OrbitalCommand",
                "Marine",
                "SupplyDepot",
                "Marine",
                "CallMule",
                "SCV",
                "Factory",
                "SCV",
                "Refinery",
                "ReactorOnBarracks",
                "SCV",
                "GasScv",
                "GasScv",
                "GasScv",
                "SCV",
                "SCV",
                "Starport",
                "Hellion",
                "SupplyDepot",
                "DoubleMarines",
                "SCV",
                "CallMule",
                "TechLabOnFactory",
                "SCV",
                "DoubleMarines",
                "SupplyDepot",
                "SCV",
                "LiftFactoryFromTechLab",
                "LandStarportOnTechLab",
                "DoubleMarines",
                "SCV",
                "Raven"
            };

			return bo;
		}

		private static BuildOrderInfo ConstructSpeedlingExpandBuild()
		{
			var bo = new BuildOrderInfo
					{
						Name = "Speedling Expand",
						Description = "Safe zerg build order",
						Race = "Zerg",
						VsRace = "NotDefined",
						SC2VersionID = "2.0.5",
						AddonID = "WOL"
					};

			bo.BuildOrderItems = new List<string>
                {
                    "Drone",
                    "Drone",
                    "Drone",
                    "Overlord",
                    "Drone",
                    "Drone",
                    "Drone",
                    "Drone",
                    "Drone",
                    "Extractor",
                    "Drone",
                    "SpawningPool",
                    "GasDrone",
                    "GasDrone",
                    "GasDrone",
                    "Drone",
                    "Drone",
                    "Drone",
                    "Overlord",
                    "MetabolicBoost",
                    "Queen",
                    "Zergling",
                    "Drone",
                    "Hatchery",
                    "Drone",
                    "Queen",
                };

			return bo;
		}

		#endregion
	}
}
