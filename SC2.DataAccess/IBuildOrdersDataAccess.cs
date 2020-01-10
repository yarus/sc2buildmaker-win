using System.Collections.Generic;
using SC2.PublicData;

namespace SC2.DataAccess
{
    public interface IBuildOrdersDataAccess
    {
        IEnumerable<BuildOrderInfo> GetBuildOrders();

        void SaveBuildOrder(BuildOrderInfo bo);
    }
}
