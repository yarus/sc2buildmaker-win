using System.Collections.Generic;
using SC2.DataAccess;
using SC2.Entities;

namespace SC2.DataManagers
{
    public class BuildOrdersManager : IBuildOrdersManager
    {
        private readonly IBuildOrdersDataAccess mDataAccess;

        private readonly Dictionary<string, BuildOrderEntity> mLoadedBuildOrders;

        public BuildOrdersManager(IBuildOrdersDataAccess dataAccess)
        {
            this.mDataAccess = dataAccess;

            this.mLoadedBuildOrders = new Dictionary<string, BuildOrderEntity>();
        }

        public IEnumerable<BuildOrderEntity> GetBuildOrders()
        {
            var result = new List<BuildOrderEntity>();

            var buildOrders = this.mDataAccess.GetBuildOrders();

            foreach (var buildOrderInfo in buildOrders)
            {
                var entity = InfoEntityConverter.Convert(buildOrderInfo);
                result.Add(entity);
                this.mLoadedBuildOrders[entity.Name] = entity;
            }

            return this.mLoadedBuildOrders.Values;
        }

        public BuildOrderEntity GetBuildOrder(string name)
        {
            if (!this.mLoadedBuildOrders.ContainsKey(name))
            {
                this.GetBuildOrders();
            }

            return this.mLoadedBuildOrders[name];
        }

        public void SaveBuildOrder(BuildOrderEntity buildOrder)
        {
            var info = InfoEntityConverter.Convert(buildOrder);

            this.mDataAccess.SaveBuildOrder(info);

            this.mLoadedBuildOrders[buildOrder.Name] = buildOrder;
        }
    }
}
