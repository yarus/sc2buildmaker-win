using System;
using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class SecondsPassedRequirement : IBuildItemRequirement
    {
        public int Seconds { get; private set; }

        public string RequirementName { get { return BuildItemRequirementFactory.SecondsPassedRequirement; } }

        public SecondsPassedRequirement(int seconds)
        {
            this.Seconds = seconds;
        }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "Seconds", Value = this.Seconds.ToString(CultureInfo.InvariantCulture)}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName("IdleSeconds") == 0;
        }
    }
}
