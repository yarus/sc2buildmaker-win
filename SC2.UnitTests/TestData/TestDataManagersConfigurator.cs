using SC2.DataManagers;
using SC2.UnitTests.TestData.WOL;

namespace SC2.UnitTests.TestData
{
    public class TestDataManagersConfigurator : IDataManagersConfigurator
    {
        public IBuildOrdersManager GetBuildOrdersManager()
        {
            return new TestBuildOrdersManager();
        }

        public ISC2VersionsManager GetSC2VersionsManager()
        {
            return new TestSC2VersionManager();
        }
    }
}
