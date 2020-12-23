using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class IdleModule : BuildManagerModuleBase
    {
        public static string StartIdle = "StartIdleEnabled";
        public static string IdleTimer = "IdleTimer";

        public override string ModuleName
        {
            get { return "IdleModule"; }
        }
        
        public override void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            var startIdle = stats.GetStatValueByName(StartIdle);

            if (startIdle == 0)
            {
                stats.SetItemCountForName(IdleTimer, 0);
            }
        }        

        public override void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
            var startIdle = stats.GetStatValueByName(StartIdle);

            if (startIdle > 0)
            {
                stats.ChangeItemCountForName(IdleTimer, 1);
            }
            else
            {
                stats.SetItemCountForName(IdleTimer, 0);
            }
        }
    }
}