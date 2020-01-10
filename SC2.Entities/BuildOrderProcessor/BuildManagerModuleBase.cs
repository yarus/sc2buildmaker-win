using System.Collections.Generic;
using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor
{
    public abstract class BuildManagerModuleBase : IBuildOrderProcessorModule
    {
        protected BuildOrderProcessorData BuildOrder { get; private set; }

        protected BuildOrderProcessorConfiguration BuildManagerConfiguration { get; private set; }

        public abstract string ModuleName { get; }

        public virtual void AdjustModuleStatsForStep(BuildItemStatistics stats)
        {
        }

        public virtual void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats)
        {
        }

        public virtual void AdjustModuleStatsByFinishedItems(IEnumerable<BuildOrderProcessorItem> finishedItems, BuildItemStatistics stats)
        {
        }

        public virtual void AdjustModuleStatsByUndoItem(BuildOrderProcessorItem undoBoItem, BuildOrderProcessorItem newLastItem)
        {
        }

        public virtual void InitBuildOrder(BuildOrderProcessorData buildOrder, BuildOrderProcessorConfiguration config)
        {
            this.BuildOrder = buildOrder;
            this.BuildManagerConfiguration = config;
        }
    }
}
