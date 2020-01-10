using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Requirements;

namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class LarvaModule : BuildManagerModuleBase
    {
        public virtual int InjectedLarvaAdd
        {
            get { return 4; }
        }

        public virtual int SpawnLarvaTime
        {
            get { return 15; }
        }

        public override string ModuleName
        {
            get { return "LarvaModule"; }
        }

        public override void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
            var larvaTimers = stats.GetStatsWithKeyContains("LarvaTimer");
            var larvaCounts = stats.GetStatsWithKeyContains("LarvaCount");
            var injectedTimer = stats.GetStatsWithKeyContains("InjectedTimer");

            if (larvaTimers.Count == 0 && injectedTimer.Count == 0) return;

            foreach (var timer in larvaTimers)
            {
                var hatcheryName = timer.Key.Substring(0, timer.Key.Length - "LarvaTimer".Length);
                var larvaCountStat = larvaCounts.FirstOrDefault(p => p.Key.Contains(hatcheryName));
                
                if (larvaCountStat.Value < 3)
                {
                    stats.ChangeItemCountForName(timer.Key, 1);
                }
                else
                {
                    stats.SetItemCountForName(timer.Key, 0);
                }

                var newTime = stats.GetStatValueByName(timer.Key);

                if (newTime == SpawnLarvaTime)
                {
                    stats.ChangeItemCountForName(larvaCountStat.Key, 1);
                    stats.SetItemCountForName(timer.Key, 0);
                }
            }

            foreach (var injectTimer in injectedTimer)
            {
                string hatcheryName = injectTimer.Key.Substring(0, injectTimer.Key.Length - "InjectedTimer".Length);
                int larvaCount = stats.GetStatValueByName(hatcheryName + "LarvaCount");

                stats.ChangeItemCountForName(hatcheryName + "InjectedTimer", 1);

                var newInjectTimerValue = stats.GetStatValueByName(injectTimer.Key);

                int injectTime = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem("InjectLarva").BuildTimeInSeconds;

                if (newInjectTimerValue > injectTime)
                {
                    int larvaChange = InjectedLarvaAdd;
                    if ((larvaCount + larvaChange) > 19)
                    {
                        larvaChange = 19 - larvaCount;
                    }

                    stats.ChangeItemCountForName(hatcheryName + "LarvaCount", larvaChange);
                    stats.ChangeItemCountForName("TotalLarva", larvaChange);
                    stats.RemoveStat(hatcheryName + "InjectedTimer");
                }
            }

            this.ResetTotalLarva(stats);
        }

        public override void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            if (item.Name == "InjectLarva")
            {
                // TODO:
                var injectedHatcheries = stats.GetStatsWithKeyContains("InjectedTimer");
                int totalHatcheries = stats.GetStatValueByName("Hatchery");

                if (injectedHatcheries.Count >= totalHatcheries)
                {
                    throw new ApplicationException("All hatcheries are buzy");
                }

                var injectedHatchList = stats.GetStatsWithKeyContains("InjectedTimer").Select(p => p.Key.Substring(0, p.Key.Length - "InjectedTimer".Length)).ToList();
                string hatchToInject = string.Empty;

                for (int i = 1; i <= totalHatcheries; i++)
                {
                    var hatchName = "Hatchery" + i;
                    if (!injectedHatchList.Contains(hatchName))
                    {
                        hatchToInject = hatchName;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(hatchToInject))
                {
                    throw new ApplicationException("All hatcheries are buzy");
                }

                stats.SetItemCountForName(hatchToInject + "InjectedTimer", 1);
                
                return;
            }

            var larvaRequirement = item.ProduceRequirements.FirstOrDefault(p => p is LarvaRequirement) as LarvaRequirement;
            if (larvaRequirement == null) return;

            int requiredLarva = larvaRequirement.RequiredValue;

            var larvaCounts = stats.GetStatsWithKeyContains("LarvaCount");
            foreach (var larvaCount in larvaCounts)
            {
                if (larvaCount.Value >= requiredLarva)
                {
                    stats.SetItemCountForName(larvaCount.Key, larvaCount.Value - requiredLarva);
                    break;
                }

                requiredLarva = requiredLarva - larvaCount.Value;
                stats.SetItemCountForName(larvaCount.Key, 0);
            }

            this.ResetTotalLarva(stats);
        }

        public override void AdjustModuleStatsByFinishedItems(IEnumerable<BuildOrderProcessorItem> finishedItems, BuildItemStatistics stats)
        {
            var finishedHatcheries = finishedItems.Where(p => p.ItemName == "Hatchery").ToList();
            int hatcheryCount = stats.GetStatValueByName("Hatchery");

            foreach (var finishedHatchery in finishedHatcheries)
            {
                var hatchOrder = finishedHatchery.ItemName + (hatcheryCount++).ToString(CultureInfo.InvariantCulture);
                stats.SetItemCountForName(hatchOrder + "LarvaCount", 1);
                stats.SetItemCountForName(hatchOrder + "LarvaTimer", 0);
            }
        }

        private void ResetTotalLarva(BuildItemStatistics stats)
        {
            var larvaCounts = stats.GetStatsWithKeyContains("LarvaCount");
            if (larvaCounts.Count == 0)
            {
                stats.SetItemCountForName("TotalLarva", 0);
            }
            else
            {
                stats.SetItemCountForName("TotalLarva", larvaCounts.Sum(p => p.Value));
            }
        }
    }
}
