using SC2.Entities.BuildItems;

namespace SC2.Entities.BuildOrderProcessor
{
    public class BuildOrderProcessorItem
    {
        public string ItemName { get; private set; }

        public int Order { get; private set; }

        public int SecondInTimeLine { get; set; }

        public int FinishedSecond { get; set; }

        public BuildItemStatistics StatisticsProvider { get; private set; }

        public BuildOrderProcessorItem(int secondInTimeLine, BuildItemEntity item, BuildItemStatistics statisticsProvider, int order)
        {
            this.SecondInTimeLine = secondInTimeLine;
            this.StatisticsProvider = statisticsProvider;
            this.FinishedSecond = secondInTimeLine + item.BuildTimeInSeconds;
            this.ItemName = item.Name;
            this.Order = order;
        }
    }
}