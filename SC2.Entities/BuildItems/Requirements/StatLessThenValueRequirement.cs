using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class StatLessThenValueRequirement : IBuildItemRequirement
    {
        public string TargetStatisticName { get; private set; }
        public int Value { get; private set; }

        public StatLessThenValueRequirement(string targetStatisticName, int value)
        {
            this.TargetStatisticName = targetStatisticName;
            this.Value = value;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.StatLessThenValueRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "TargetStatName", Value = this.TargetStatisticName},
                    new NameValueInfo {Name = "Value", Value = this.Value.ToString(CultureInfo.InvariantCulture)}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName(this.TargetStatisticName) < this.Value;
        }
    }
}
