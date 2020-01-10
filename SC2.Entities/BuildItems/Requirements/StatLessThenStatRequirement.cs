using System.Collections.Generic;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class StatLessThenStatRequirement : IBuildItemRequirement
    {
        public string LeftStatistic { get; private set; }
        public string RightStatistic { get; private set; }

        public StatLessThenStatRequirement(string leftStatistic, string rightStatistic)
        {
            this.LeftStatistic = leftStatistic;
            this.RightStatistic = rightStatistic;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.StatLessThenStatRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "LeftStatistic", Value = this.LeftStatistic},
                    new NameValueInfo {Name = "RightStatistic", Value = this.RightStatistic}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName(this.LeftStatistic) < stats.GetStatValueByName(this.RightStatistic);
        }
    }
}
