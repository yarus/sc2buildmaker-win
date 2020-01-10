using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor.Modules
{
    public class ResourceModule : BuildManagerModuleBase
    {
        public override string ModuleName
        {
            get { return "ResourceModule"; }
        }

        public override void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
            var resourceChange = this.GetResourceChangeForPeriod(1, stats);
            stats.Minerals += resourceChange.Minerals;
            stats.Gas += resourceChange.Gas;
        }

        public override void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            stats.Gas -= item.CostGas;
            stats.Minerals -= item.CostMinerals;
        }

        #region Resource calculation common methods

        private ResourcesEntity GetResourceChangeForPeriod(int secondsInPeriod, BuildItemStatistics basePointStats)
        {
            var mineralsPerMinute = this.GetMineralsPerMinute(basePointStats);
            var gasPerMinute = this.GetGasPerMinute(basePointStats);

            var incomeInfo = new ResourcesEntity
            {
                Minerals = this.GetAdjustedWithMilliResourcePerPeriod(mineralsPerMinute, secondsInPeriod, Consts.CoreStatistics.MilliMinerals, basePointStats),
                Gas = this.GetAdjustedWithMilliResourcePerPeriod(gasPerMinute, secondsInPeriod, Consts.CoreStatistics.MilliGas, basePointStats)
            };

            return incomeInfo;
        }

        private int GetAdjustedWithMilliResourcePerPeriod(int resourcePerMinute, int secondsInPeriod,
                                                          string milliResourceStatName,
                                                          BuildItemStatistics basePointStats)
        {
            int resultResource = 0;

            if (resourcePerMinute < 60)
            {
                int milliValue = (resourcePerMinute*100/60);
                basePointStats.ChangeItemCountForName(milliResourceStatName, milliValue);
                if (basePointStats.GetStatValueByName(milliResourceStatName) > 100)
                {
                    resultResource = 1;
                    basePointStats.ChangeItemCountForName(milliResourceStatName, -100);
                }
            }
            else
            {
                resultResource = resourcePerMinute > 0 ? (resourcePerMinute/60)*secondsInPeriod : 0;
                var milliValue = resourcePerMinute - resultResource*60;
                basePointStats.ChangeItemCountForName(milliResourceStatName, milliValue);
                if (basePointStats.GetStatValueByName(milliResourceStatName) > 100)
                {
                    resultResource++;
                    basePointStats.ChangeItemCountForName(milliResourceStatName, -100);
                }
            }

            return resultResource;
        }

        private int GetMineralsPerMinute(BuildItemStatistics basePointStats)
        {
            int result = this.CalculateResourcePerMinute(
                basePointStats.BasesCount,
                this.BuildManagerConfiguration.GlobalConstants.MineralsPatchesPerBase,
                basePointStats.WorkersOnMinerals,
                this.BuildManagerConfiguration.GlobalConstants.MineralsPerMinuteFrom3WorkersPerPatch,
                this.BuildManagerConfiguration.GlobalConstants.MineralsPerMinuteFrom2WorkersPerPatch,
                this.BuildManagerConfiguration.GlobalConstants.MineralsPerMinuteFrom1WorkerPerPatch);

            if (basePointStats.MulesOnMinerals > 0)
            {
                result += basePointStats.MulesOnMinerals*
                          this.BuildManagerConfiguration.GlobalConstants.MineralsPerMinuteFrom1Mule;
            }

            return result;
        }

        private int GetGasPerMinute(BuildItemStatistics basePointStats)
        {
            return this.CalculateResourcePerMinute(
                basePointStats.BasesCount,
                this.BuildManagerConfiguration.GlobalConstants.GasPatchesPerBase,
                basePointStats.WorkersOnGas,
                this.BuildManagerConfiguration.GlobalConstants.GasPerMinuteFrom3WorkersPerPatch,
                this.BuildManagerConfiguration.GlobalConstants.GasPerMinuteFrom2WorkersPerPatch,
                this.BuildManagerConfiguration.GlobalConstants.GasPerMinuteFrom1WorkerPerPatch);
        }

        private int CalculateResourcePerMinute(int basesCount, int patchesPerBase, int workersCountOnResource,
                                               int incomeFrom3Workers, int incomeFrom2Workers, int incomeFrom1Worker)
        {
            int n = workersCountOnResource;
            int d = basesCount*patchesPerBase;
            int i3 = incomeFrom3Workers;
            int i2 = incomeFrom2Workers;
            int i1 = incomeFrom1Worker;

            int incomePerMinuteForPeriod = 0;

            if (n >= 3*d)
            {
                incomePerMinuteForPeriod = d*i3;
            }
            else if (n >= 2*d && n < 3*d)
            {
                int d3 = n - d*2;
                int d2 = d - d3;
                incomePerMinuteForPeriod = d3*i3 + d2*i2;
            }
            else if (n >= d && n < 2*d)
            {
                int d2 = n - d;
                int d1 = d - d2;
                incomePerMinuteForPeriod = d2*i2 + d1*i1;
            }
            else if (n <= d)
            {
                incomePerMinuteForPeriod = i1*n;
            }

            return incomePerMinuteForPeriod;
        }

        #endregion
    }
}
