using System;
using System.Collections.Generic;
using System.Linq;
using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class LotvChronoboostModule : BuildManagerModuleBase
    {
        public override string ModuleName
        {
            get { return "LotvChronoboostModule"; }
        }

        public override void AdjustModuleStatsByUndoItem(BuildOrderProcessorItem undoBoItem, BuildOrderProcessorItem newLastItem)
        {
            if (undoBoItem.ItemName == "Chronoboost")
            {
                if (undoBoItem.SecondInTimeLine == undoBoItem.FinishedSecond) { return; }

                // Recalculate boosted item finish time
                int boostItemOrder = newLastItem.StatisticsProvider.GetStatValueByName("LastItemOrder");

                if (boostItemOrder == 0)
                {
                    return;
                }

                BuildItemEntity boostItem = BuildManagerConfiguration.BuildItemsDictionary.GetItem(newLastItem.ItemName);

                newLastItem.FinishedSecond = newLastItem.SecondInTimeLine + boostItem.BuildTimeInSeconds;
            }
        }

        public override void AdjustModuleStatsByFinishedItems(IEnumerable<BuildOrderProcessorItem> finishedItems, BuildItemStatistics stats)
        {
            foreach (var item in finishedItems)
            {
                if (item.ItemName == "Nexus")
                {
                    stats.ChangeItemCountForName("BoostedNexusCount", 1);
                    continue;
                }

                var entity = this.BuildManagerConfiguration.BuildItemsDictionary.GetItem(item.ItemName);
                if (entity.ProductionBuildingName == "Nexus")
                {
                    int initialBuildTime = entity.BuildTimeInSeconds;
                    int realBuildTime = item.FinishedSecond - item.SecondInTimeLine;

                    if (realBuildTime < initialBuildTime)
                    {
                        stats.ChangeItemCountForName("NexusBoostedBuzy", -1);   
                    }
                }
            }

            var chronoTimers = stats.GetStatsWithKeyContains("ChronoTimer");
            foreach (var timer in chronoTimers)
            {
                if (timer.Value == 0)
                {
                    var boostedNexusCount = stats.GetStatValueByName("BoostedNexusCount");
                    var nexusCount = stats.GetStatValueByName("Nexus");

                    if (nexusCount > boostedNexusCount)
                    {
                        stats.ChangeItemCountForName("BoostedNexusCount", 1);
                        // recalculate current building item from unboosted nexus
                    }

                    stats.RemoveStat(timer.Key);
                }
            }
        }

        public override void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
            // if boost timer completed -> move it to not boosted nexus back and recalculate building time for currently building item
            var chronoTimers = stats.GetStatsWithKeyContains("ChronoTimer");
            foreach (var timer in chronoTimers)
            {
                if (timer.Value != 0)
                {
                    stats.ChangeItemCountForName(timer.Key, -1);
                }
            }

            var chronoBuzyTimers = stats.GetStatsWithKeyContains("ChronoBuzyTimer");
            foreach (var timer in chronoBuzyTimers)
            {
                if (timer.Value != 0)
                {
                    stats.ChangeItemCountForName(timer.Key, -1);
                }
                else
                {
                    stats.ChangeItemCountForName("NexusBoostedBuzy", 1);
                    stats.RemoveStat(timer.Key);
                }
            }
        }

        public override void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            if (item.Name == "DefaultItem")
            {
                stats.ChangeItemCountForName("BoostedNexusCount", 1);
                return;
            }

            if (item.ProductionBuildingName == "Nexus")
            {
                stats.SetItemCountForName("ChronoboostAvailable", 0);

                int boostedNexus = stats.GetStatValueByName("BoostedNexusCount");
                int boostedNexusBuzy = stats.GetStatValueByName("NexusBoostedBuzy");

                if (boostedNexus > boostedNexusBuzy)
                {
                    stats.ChangeItemCountForName("NexusBoostedBuzy", 1);
                    int secondsToCompleteBuilding = boItem.FinishedSecond - boItem.SecondInTimeLine;
                    int secondsToCompleteWithBoost = (int) Math.Round(secondsToCompleteBuilding - secondsToCompleteBuilding*0.15);

                    boItem.FinishedSecond = boItem.SecondInTimeLine + secondsToCompleteWithBoost;
                }
                else
                {
                    // We should try to find a moment in the build when chronoboost would be released if any of timers is in progress
                    var chronoTimers = stats.GetStatsWithKeyContains("ChronoTimer");
                    if (chronoTimers.Count > 0)
                    {
                        int fastestChronoRelease = chronoTimers.Min(p => p.Value);
                        if (item.BuildTimeInSeconds > fastestChronoRelease)
                        {
                            int boostedTime = boItem.FinishedSecond - boItem.SecondInTimeLine - fastestChronoRelease;
                            int boostedTimeWithBoost = (int)Math.Round(boostedTime - boostedTime * 0.15);
                            //var boostedTimeWithBoost = boostedTime / 1.5;

                            boItem.FinishedSecond = boItem.SecondInTimeLine + fastestChronoRelease + boostedTimeWithBoost;

                            stats.SetItemCountForName("ChronoBuzyTimer" + boItem.Order, fastestChronoRelease);
                        }
                    }
                }

                return;
            }

            if (item.Name == "Chronoboost")
            {
                stats.SetItemCountForName("ChronoboostAvailable", 0);

                int boostItemOrder = stats.GetStatValueByName("LastItemOrder");

                BuildOrderProcessorItem boItemToBeBoosted = null;
                BuildItemEntity entityToBeBoosted = null;

                for (int i = boostItemOrder; i > 0; i--)
                {
                    boItemToBeBoosted = BuildOrder.GetBuildOrderItemsClone().First(p => p.Order == i);
                    entityToBeBoosted = BuildManagerConfiguration.BuildItemsDictionary.GetItem(boItemToBeBoosted.ItemName);

                    if (boItemToBeBoosted.FinishedSecond < boItem.SecondInTimeLine)
                    {
                        return;
                    }

                    if (entityToBeBoosted.ProductionBuildingName == "Nexus")
                    {
                        continue;
                    }

                    if (entityToBeBoosted.ItemType == BuildItemTypeEnum.Unit || entityToBeBoosted.ItemType == BuildItemTypeEnum.Upgrade)
                    {
                        break;
                    }

                    boItemToBeBoosted = null;
                    entityToBeBoosted = null;
                }

                if (boItemToBeBoosted == null || entityToBeBoosted == null)
                {
                    throw new ApplicationException("Build processor were unable to find item to be boosted");
                }

                int unbooStedTime = 0;

                if (boItem.SecondInTimeLine > boItemToBeBoosted.SecondInTimeLine)
                {
                    unbooStedTime = boItem.SecondInTimeLine - boItemToBeBoosted.SecondInTimeLine;
                }

                int boostedTime = boItemToBeBoosted.FinishedSecond - boItem.SecondInTimeLine;

                int boostedTimeWithBoost = (int)Math.Round(boostedTime - boostedTime * 0.15);

                boItemToBeBoosted.FinishedSecond = boItemToBeBoosted.SecondInTimeLine + unbooStedTime + boostedTimeWithBoost;

                boItem.FinishedSecond = boItemToBeBoosted.FinishedSecond;
         
                stats.ChangeItemCountForName("BoostedNexusCount", -1);

                stats.SetItemCountForName("ChronoTimer" + boostItemOrder, boItemToBeBoosted.FinishedSecond - boItem.SecondInTimeLine);

                return;
            }

            if (item.ItemType == BuildItemTypeEnum.Unit || item.ItemType == BuildItemTypeEnum.Upgrade)
            {
                stats.SetItemCountForName("LastItemOrder", boItem.Order);

                stats.SetItemCountForName("ChronoboostAvailable", 1);
            }
        }
    }
}