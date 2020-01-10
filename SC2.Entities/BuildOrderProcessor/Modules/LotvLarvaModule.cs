namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class LotvLarvaModule : LarvaModule
    {
        public override string ModuleName
        {
            get { return "LotvLarvaModule"; }
        }

        public override int InjectedLarvaAdd
        {
            get { return 3; }
        }

        public override int SpawnLarvaTime
        {
            get { return 11; }
        }
    }
}