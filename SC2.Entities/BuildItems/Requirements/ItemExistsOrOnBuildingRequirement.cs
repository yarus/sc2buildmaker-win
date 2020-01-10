using System.Collections.Generic;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class ItemExistsOrOnBuildingRequirement : IBuildItemRequirement
    {
        public string TargetItemName { get; private set; }

        public ItemExistsOrOnBuildingRequirement(string targetItemName)
        {
            this.TargetItemName = targetItemName;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.ItemExistsOrOnBuildingRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "TargetItemName", Value = this.TargetItemName}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName(this.TargetItemName) > 0 || stats.GetStatValueByName(this.TargetItemName + Consts.BuildItemOnBuildingPostfix) > 0;
        }
    }
}
