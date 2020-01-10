using System.Collections.Generic;
using SC2.PublicData;

namespace SC2.DataAccess
{
    public interface ISC2VersionsDataAccess
    {
        SC2VersionInfo GetVersionInfo(string sc2VersionID);

        IEnumerable<string> GetSupportedVersionIDs();

        void SaveSC2VersionInfo(SC2VersionInfo info);
    }
}
