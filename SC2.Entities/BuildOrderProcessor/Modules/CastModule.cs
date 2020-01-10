using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildItems.Requirements;

namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class CastModule : BuildManagerModuleBase
    {
        public const string TotalCasts = "TotalCasts";
        public const string CastTimer = "CastTimer";
        public const string CastCount = "CastCount";

        public override string ModuleName
        {
            get { return "CastModule"; }
        }

        public override void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
            var castTimers = stats.GetStatsWithKeyContains(CastTimer);
            var castCounts = stats.GetStatsWithKeyContains(CastCount);

            if (castTimers.Count == 0) return;

            foreach (var timer in castTimers)
            {
                var nexusName = timer.Key.Substring(0, timer.Key.Length - CastTimer.Length);
                var castCountStat = castCounts.FirstOrDefault(p => p.Key.Contains(nexusName));
                int castTimer = timer.Value;

                if (castCountStat.Value < this.BuildManagerConfiguration.RaceConstants.EnergyCastLimitPerEnergyGenerator)
                {
                    stats.ChangeItemCountForName(timer.Key, 1);
                }

                if (castTimer == this.BuildManagerConfiguration.RaceConstants.EnergyCastGenerateTime)
                {
                    stats.ChangeItemCountForName(castCountStat.Key, 1);
                    stats.SetItemCountForName(timer.Key, 0);
                }
            }

            this.ResetTotalCast(stats);
        }

        public override void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            if (item.Name == Consts.DefaultStateItemName)
            {
                int energyGeneratorCount = stats.GetStatValueByName(this.BuildManagerConfiguration.RaceConstants.EnergyGeneratorBuildItemName);
                int energyForNewBase = this.BuildManagerConfiguration.RaceConstants.EnergyCastCountForNewEnergyGenerator;
                string energyGeneratorName = this.BuildManagerConfiguration.RaceConstants.EnergyGeneratorBuildItemName;

                stats.ChangeItemCountForName("TotalCasts", energyGeneratorCount * energyForNewBase);

                for (int i = 0; i < energyGeneratorCount; i++)
                {
                    stats.ChangeItemCountForName(energyGeneratorName + (i + 1) + "CastCount", energyForNewBase);
                    stats.ChangeItemCountForName(energyGeneratorName + (i + 1) + "CastTimer", 0);
                }
            }

            var castRequirement = item.ProduceRequirements.FirstOrDefault(p => p is CastRequirement) as CastRequirement;
            if (castRequirement == null) return;

            this.UseCast(stats);
        }

        public void UseCast(BuildItemStatistics stats)
        {
            var castCounts = stats.GetStatsWithKeyContains(CastCount);
            
            string castBuilding = string.Empty;
            int castCountValue = 0;

            foreach (var castCount in castCounts)
            {
                if (castCount.Value >= 1)
                {
                    castBuilding = castCount.Key;
                    castCountValue = castCount.Value;
                    break;
                }
            }

            if (string.IsNullOrEmpty(castBuilding))
            {
                var castTimers = stats.GetStatsWithKeyContains(CastTimer);

                if (castTimers.Count == 0)
                {
                    throw new ApplicationException("Energy generators are unavailable");
                }

                var maxTimer = castTimers.Max(p => p.Value);
                castBuilding = castTimers.First(p => p.Value == maxTimer).Key;
                castBuilding = castBuilding.Substring(0, castBuilding.Length - CastTimer.Length);
                castCountValue = stats.GetStatValueByName(castBuilding + CastCount);
                castBuilding = castBuilding + CastCount;
            }

            stats.SetItemCountForName(castBuilding, castCountValue - 1);

            this.ResetTotalCast(stats);
        }

        public override void AdjustModuleStatsByFinishedItems(IEnumerable<BuildOrderProcessorItem> finishedItems, BuildItemStatistics stats)
        {
            var finishedenergyGenerators = finishedItems.Where(p => p.ItemName == this.BuildManagerConfiguration.RaceConstants.EnergyGeneratorBuildItemName).ToList();

            if (finishedenergyGenerators.Count == 0) return;

            int energyGeneratorCount = stats.GetStatValueByName(this.BuildManagerConfiguration.RaceConstants.EnergyGeneratorBuildItemName);

            foreach (var finishedGenerator in finishedenergyGenerators)
            {
                var energyGeneratorOrder = finishedGenerator.ItemName + (energyGeneratorCount++).ToString(CultureInfo.InvariantCulture);
                stats.SetItemCountForName(energyGeneratorOrder + CastCount, this.BuildManagerConfiguration.RaceConstants.EnergyCastCountForNewEnergyGenerator);
                stats.SetItemCountForName(energyGeneratorOrder + CastTimer, 0);
            }
        }

        private void ResetTotalCast(BuildItemStatistics stats)
        {
            var castCounts = stats.GetStatsWithKeyContains(CastCount);
            if (castCounts.Count == 0)
            {
                stats.SetItemCountForName(TotalCasts, 0);
            }
            else
            {
                stats.SetItemCountForName(TotalCasts, castCounts.Sum(p => p.Value));
            }
        }
    }
}
