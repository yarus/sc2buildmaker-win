using System.Collections.Generic;
using SC2.DataAccess;
using SC2.DataAccess.FileStorage;
using SC2.DataManagers;
using SC2.Entities;

namespace SC2.UnitTests.TestData.HOTS
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
	}
}
