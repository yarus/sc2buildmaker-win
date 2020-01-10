using System;
using System.Collections.Generic;
using SC2.DataAccess;
using SC2.DataAccess.FileStorage;
using SC2.DataManagers;
using SC2.Entities;
using SC2.UnitTests.TestData.HOTS;

namespace SC2.UnitTests.TestData
{
    public class TestSC2VersionManager : ISC2VersionsManager
	{
		public SC2VersionEntity GetVersion(string versionID)
		{
            if (versionID == "2.0.5")
			{
				return SC2.UnitTests.TestData.WOL.TestDataFixture.GetVersionEntity();
			}

            if (versionID == "2.2.0")
			{
				return TestDataFixture.GetVersionEntity();
			}

            if (versionID == "4.11.3")
		    {
		        return SC2.UnitTests.TestData.LOTV.TestDataFixture.GetVersionEntity();
		    }

			throw new NotImplementedException("Unsupported version ID");
		}

		public IEnumerable<string> GetSupportedVersionIDs()
		{
			return new[] { "4.11.3", "2.2.0", "2.0.5" };
		}

		public void SaveVersion(SC2VersionEntity verion)
		{
			var info = InfoEntityConverter.Convert(verion);
			var dataAccess = new SC2VersionsDataAccess(new JsonStorageDataAccess(), "Versions//");
			dataAccess.SaveSC2VersionInfo(info);
		}
	}
}