using System.Collections.Generic;

namespace SC2.Entities.BuildItems
{
    public class BuildItemEntity
    {
        private string mDisplayName;

        public BuildItemEntity()
        {
            this.OrderRequirements = new List<IBuildItemRequirement>();
            this.ProduceRequirements = new List<IBuildItemRequirement>();
            this.OrderedActions = new List<IBuildItemAction>();
            this.ProducedActions = new List<IBuildItemAction>();
        }

        public int BuildTimeInSeconds { get; set; }

        public string Name { get; set; }
        
        public string DisplayName
        {
            get
            {
                return string.IsNullOrEmpty(this.mDisplayName) ? this.Name : this.mDisplayName;
            }
            set
            {
                this.mDisplayName = value;
            }
        }

        public string ProductionBuildingName { get; set; }
        
        public string ImagePath { get; set; }

        public int CostMinerals { get; set; }

        public int CostGas { get; set; }

        public int CostSupply { get; set; }

        public BuildItemTypeEnum ItemType { get; set; }

        public List<IBuildItemRequirement> OrderRequirements { get; set; }
        public List<IBuildItemRequirement> ProduceRequirements { get; set; }

        public List<IBuildItemAction> OrderedActions { get; set; }
        public List<IBuildItemAction> ProducedActions { get; set; }
    }
}