using System.Collections.Generic;
using System.Linq;

namespace SC2.Entities.BuildOrderProcessor
{
    public class BuildOrderProcessorData
    {
        public string Name { get; set; }
        public string SC2VersionID { get; set; }
        public string Description { get; set; }
        public RaceEnum Race { get; set; }
        public RaceEnum VsRace { get; set; }

        public BuildOrderProcessorItem LastBuildItem { get; private set; }
        private List<BuildOrderProcessorItem> BuildItems { get; set; }

        public BuildOrderProcessorData()
        {
            this.BuildItems = new List<BuildOrderProcessorItem>();
        }

        public void AddBuildItem(BuildOrderProcessorItem item)
        {
            this.BuildItems.Add(item);
            this.LastBuildItem = item;
        }

        public BuildOrderEntity GenerateBuildOrderEntity()
        {
            return new BuildOrderEntity()
            {
                Name = this.Name,
                Description = this.Description,
                Race = this.Race,
                BuildOrderItems = this.GetBuildOrderItemsClone().Select(p => p.ItemName).ToList(),
                SC2VersionID = this.SC2VersionID,
                VsRace = this.VsRace
            };
        }

        public List<BuildOrderProcessorItem> GetBuildOrderItemsClone()
        {
            return new List<BuildOrderProcessorItem>(this.BuildItems);
        }

        public List<BuildOrderProcessorItem> GetFinishedItemsClone(int secondInTimeLine)
        {
            var finishedItems = this.BuildItems.Where(p => p.FinishedSecond == secondInTimeLine);
            return new List<BuildOrderProcessorItem>(finishedItems);
        }

        public void RemoveLastItem()
        {
            if (this.LastBuildItem == null) return;

            var newLastItem = this.GetItemBefore(this.LastBuildItem);
            this.BuildItems.Remove(this.LastBuildItem);
            this.LastBuildItem = newLastItem;
        }

        public BuildOrderProcessorItem GetItemBefore(BuildOrderProcessorItem baseItem)
        {
            return this.BuildItems.Where(i => i.Order < baseItem.Order).OrderByDescending(p => p.Order).FirstOrDefault();
        }
    }
}