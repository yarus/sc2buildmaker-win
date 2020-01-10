using System.Collections.Generic;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class StatBiggerOrEqualThenStatRequirement : IBuildItemRequirement
    {
        public string LeftStatName { get; private set; }

        public string RightStatName { get; private set; }

        public StatBiggerOrEqualThenStatRequirement(string leftStatName, string rightStatName)
        {
            this.LeftStatName = leftStatName;
            this.RightStatName = rightStatName;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.StatBiggerOrEqualThenStatRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "LeftStatName", Value = this.LeftStatName},
                    new NameValueInfo {Name = "RightStatName", Value = this.RightStatName}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName(this.LeftStatName) >= stats.GetStatValueByName(this.RightStatName);
        }
    }
}
