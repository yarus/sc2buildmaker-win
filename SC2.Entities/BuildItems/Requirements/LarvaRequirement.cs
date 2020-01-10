using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class LarvaRequirement : IBuildItemRequirement
    {
        public int RequiredValue { get; private set; }

        public LarvaRequirement(int requiredValue)
        {
            this.RequiredValue = requiredValue;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.LarvaRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "RequiredValue", Value = this.RequiredValue.ToString(CultureInfo.InvariantCulture)}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName("TotalLarva") >= this.RequiredValue;
        }
    }
}
