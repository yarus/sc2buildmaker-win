namespace SC2.DataManagers
{
    public interface IDataManagersConfigurator
    {
        IBuildOrdersManager GetBuildOrdersManager();
        ISC2VersionsManager GetSC2VersionsManager();
    }
}