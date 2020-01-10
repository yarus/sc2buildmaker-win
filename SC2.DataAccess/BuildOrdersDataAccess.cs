using System.Collections.Generic;
using SC2.DataAccess.FileStorage;
using SC2.PublicData;

namespace SC2.DataAccess
{
    public class BuildOrdersDataAccess : IBuildOrdersDataAccess
    {
        private const string BuildOrdersFolder = "BuildOrders//";

        private readonly IStorageDataAccess mStorageDataAccess;

        public BuildOrdersDataAccess(IStorageDataAccess storageDataAccess)
        {
            this.mStorageDataAccess = storageDataAccess;
        }

        public IEnumerable<BuildOrderInfo> GetBuildOrders()
        {
            var result = new List<BuildOrderInfo>();
            
            this.mStorageDataAccess.ProcessDirectory(BuildOrdersFolder, ref result);

            return result;
        }

        public void SaveBuildOrder(BuildOrderInfo bo)
        {
            this.mStorageDataAccess.SaveToStorage(bo, BuildOrdersFolder, bo.Name);
        }
    }
}
