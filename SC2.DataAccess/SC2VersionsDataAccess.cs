using System.Collections.Generic;
using System.Linq;
using SC2.DataAccess.FileStorage;
using SC2.PublicData;

namespace SC2.DataAccess
{
    public class SC2VersionsDataAccess : ISC2VersionsDataAccess
    {
        private const int FileExtensionLengthWithDot = 4;
        //private const string VersionsFolder = "Versions//";
        private readonly IStorageDataAccess mStorageDataAccess;
        private readonly string mVersionFolder;

        public SC2VersionsDataAccess(IStorageDataAccess storageDataAccess, string versionsFolder)
        {
            mStorageDataAccess = storageDataAccess;
            mVersionFolder = versionsFolder;
        }

        public SC2VersionInfo GetVersionInfo(string sc2VersionID)
        {
            return mStorageDataAccess.ReadFromFile<SC2VersionInfo>(mVersionFolder + sc2VersionID);
        }

        public IEnumerable<string> GetSupportedVersionIDs()
        {
            var fullFileNames = mStorageDataAccess.GetFileNamesInDirectory(mVersionFolder);

            return fullFileNames.Select(p => p.Substring(mVersionFolder.Length, p.Length - mVersionFolder.Length - FileExtensionLengthWithDot)).ToList();
        }

        public void SaveSC2VersionInfo(SC2VersionInfo info)
        {
            mStorageDataAccess.SaveToStorage(info, mVersionFolder, info.VersionID);
        }
    }
}
