using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class StatBiggerOrEqualThenStatWithAdditionRequirement : IBuildItemRequirement
    {
        public string LeftStatName { get; private set; }
        public string RightStatName { get; private set; }
        public int AdditionValue { get; private set; }

        public StatBiggerOrEqualThenStatWithAdditionRequirement(string leftStatName, string rightStatName, int additionValue)
        {
            this.LeftStatName = leftStatName;
            this.RightStatName = rightStatName;
            this.AdditionValue = additionValue;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.StatBiggerOrEqualThenStatWithAdditionRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "LeftStatName", Value = this.LeftStatName},
                    new NameValueInfo {Name = "RightStatName", Value = this.RightStatName},
                    new NameValueInfo {Name = "AdditionValue", Value = this.AdditionValue.ToString(CultureInfo.InvariantCulture)}
                }
            };

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return stats.GetStatValueByName(this.LeftStatName) >= (stats.GetStatValueByName(this.RightStatName) + this.AdditionValue);
        }
    }
}
