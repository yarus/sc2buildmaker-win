using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class StatBiggerOrEqualThenValueRequirement : IBuildItemRequirement
    {
        public string TargetStatName { get; private set; }

        public int Value { get; private set; }

        public StatBiggerOrEqualThenValueRequirement(string targetStatName, int value)
        {
            this.TargetStatName = targetStatName;
            this.Value = value;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.StatBiggerOrEqualThenValueRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "TargetStatName", Value = this.TargetStatName},
                    new NameValueInfo {Name = "Value", Value = this.Value.ToString(CultureInfo.InvariantCulture)}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName(this.TargetStatName) >= this.Value;
        }
    }
}
