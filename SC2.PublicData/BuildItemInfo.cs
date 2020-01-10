using System;
using System.Collections.Generic;

namespace SC2.PublicData
{
    [Serializable]
    public class BuildItemInfo
    {
        public int BuildTimeInSeconds { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string ProductionBuildingName { get; set; }

        public string ImagePath { get; set; }

        public int CostMinerals { get; set; }

        public int CostGas { get; set; }

        public int CostSupply { get; set; }

        public string ItemType { get; set; }

        public List<ItemWithAttributesInfo> OrderedActions { get; set; }
        public List<ItemWithAttributesInfo> ProducedActions { get; set; }
        public List<ItemWithAttributesInfo> OrderRequirements { get; set; }
        public List<ItemWithAttributesInfo> ProduceRequirements { get; set; }

        public BuildItemInfo()
        {
            this.OrderedActions = new List<ItemWithAttributesInfo>();
            this.ProducedActions = new List<ItemWithAttributesInfo>();
            this.OrderRequirements = new List<ItemWithAttributesInfo>();
            this.ProduceRequirements = new List<ItemWithAttributesInfo>();
        }
    }
}
