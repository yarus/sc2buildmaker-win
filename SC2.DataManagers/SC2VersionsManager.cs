using System.Collections.Generic;
using SC2.DataAccess;
using SC2.Entities;

namespace SC2.DataManagers
{
    public class SC2VersionsManager : ISC2VersionsManager
    {
        private readonly ISC2VersionsDataAccess mDataAccess;

        private readonly Dictionary<string, SC2VersionEntity> mLoadedVersions; 

        public SC2VersionsManager(ISC2VersionsDataAccess dataAccess)
        {
            this.mDataAccess = dataAccess;
           
            this.mLoadedVersions = new Dictionary<string, SC2VersionEntity>();
        }

        public SC2VersionEntity GetVersion(string versionID)
        {
            if (!this.mLoadedVersions.ContainsKey(versionID))
            {
                var versionInfo = this.mDataAccess.GetVersionInfo(versionID);
                var versionEntity = InfoEntityConverter.Convert(versionInfo);
                this.mLoadedVersions[versionEntity.VersionID] = versionEntity;
            }

            return this.mLoadedVersions[versionID];
        }

        public IEnumerable<string> GetSupportedVersionIDs()
        {
            return this.mDataAccess.GetSupportedVersionIDs();
        }

        public void SaveVersion(SC2VersionEntity versionEntity)
        {
            var info = InfoEntityConverter.Convert(versionEntity);
            this.mDataAccess.SaveSC2VersionInfo(info);
        }
    }
}
