using System.Collections.Generic;
using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor
{
    public interface IBuildOrderProcessorModule
    {
        string ModuleName { get; }

        void AdjustModuleStatsForStep(BuildItemStatistics stats);

        void AdjustModuleStatsByStartedItem(BuildOrderProcessorItem boItem, BuildItemEntity item, BuildItemStatistics stats);

        void AdjustModuleStatsByFinishedItems(IEnumerable<BuildOrderProcessorItem> finishedItems, BuildItemStatistics stats);

        void AdjustModuleStatsByUndoItem(BuildOrderProcessorItem undoBoItem, BuildOrderProcessorItem newLastItem);

        void InitBuildOrder(BuildOrderProcessorData buildOrder, BuildOrderProcessorConfiguration settings);
    }
}
