using System.Collections.Generic;
using SC2.Entities;

namespace SC2.DataManagers
{
    public interface ISC2VersionsManager
    {
        SC2VersionEntity GetVersion(string versionID);

        IEnumerable<string> GetSupportedVersionIDs();

        void SaveVersion(SC2VersionEntity verion);
    }
}
