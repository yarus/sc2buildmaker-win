using SC2.DataAccess;
using SC2.DataAccess.FileStorage;

namespace SC2.DataManagers.Configurators
{
    public class DataManagersJsonStorageConfigurator : IDataManagersConfigurator
    {
        private IBuildOrdersManager mBuildOrderManager;

        private ISC2VersionsManager mSC2VersionsManager;

        private readonly string mVersionsFolder;

        public DataManagersJsonStorageConfigurator(string mVersionsFolder)
        {
            this.mVersionsFolder = mVersionsFolder;
        }

        public IBuildOrdersManager GetBuildOrdersManager()
        {
            if (mBuildOrderManager == null)
            {
                mBuildOrderManager = new BuildOrdersManager(new BuildOrdersDataAccess(new JsonStorageDataAccess()));
            }

            return mBuildOrderManager;
        }

        public ISC2VersionsManager GetSC2VersionsManager()
        {
            if (mSC2VersionsManager == null)
            {
                mSC2VersionsManager = new SC2VersionsManager(new SC2VersionsDataAccess(new JsonStorageDataAccess(), mVersionsFolder));
            }

            return mSC2VersionsManager;
        }
    }
}
