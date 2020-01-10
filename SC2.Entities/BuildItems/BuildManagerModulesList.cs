using System;
using System.Collections.Generic;
using SC2.Entities.BuildOrderProcessor;

namespace SC2.Entities.BuildItems
{
    [Serializable]
    public class BuildManagerModulesList : List<IBuildOrderProcessorModule>
    {
        public void InitBuildManagerModules(BuildOrderProcessorData buildOrder, BuildOrderProcessorConfiguration config)
        {
            foreach (var module in this)
            {
                module.InitBuildOrder(buildOrder, config);
            }
        }

        public void AdjustModulesStatsForUndo(BuildOrderProcessorItem undoBoItem, BuildOrderProcessorItem newLastItem)
        {
            foreach (var stepModule in this)
            {
                stepModule.AdjustModuleStatsByUndoItem(undoBoItem, newLastItem);
            }
        }

        public void AdjustModulesStatsForStep(BuildItemStatistics stats)
        {
            foreach (var stepModule in this)
            {
                stepModule.AdjustModuleStatsForStep(stats);
            }
        }

        public void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
            foreach (var buildStepModule in this)
            {
                buildStepModule.AdjustModuleStatsByStartedItem(boItem, item, stats);
            }
        }

        public void AdjustModelStatsByFinishedItems(List<BuildOrderProcessorItem> finishedItems, BuildItemStatistics stats)
        {
            foreach (var buildStepModule in this)
            {
                buildStepModule.AdjustModuleStatsByFinishedItems(finishedItems, stats);
            }
        }
    }
}
