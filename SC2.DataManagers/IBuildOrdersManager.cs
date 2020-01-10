using System.Collections.Generic;
using SC2.Entities;

namespace SC2.DataManagers
{
    public interface IBuildOrdersManager
    {
        IEnumerable<BuildOrderEntity> GetBuildOrders();
        BuildOrderEntity GetBuildOrder(string name);
        void SaveBuildOrder(BuildOrderEntity entity);
    }
}