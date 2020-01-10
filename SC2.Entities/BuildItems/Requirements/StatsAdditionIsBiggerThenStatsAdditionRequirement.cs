using System.Collections.Generic;
using System.Linq;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class StatsAdditionIsBiggerThenStatsAdditionRequirement : IBuildItemRequirement
    {
        public IEnumerable<string> LeftAddition { get; private set; }
        public IEnumerable<string> RightAddition { get; private set; }

        public StatsAdditionIsBiggerThenStatsAdditionRequirement(IEnumerable<string> leftAddition, IEnumerable<string> rightAddition)
        {
            this.LeftAddition = leftAddition;
            this.RightAddition = rightAddition;
        }

        private int CalculateAddition(BuildItemStatistics statistics, IEnumerable<string> statsToAddition)
        {
            return statsToAddition.Sum(stat => statistics.GetStatValueByName(stat));
        }

        public string RequirementName { get { return BuildItemRequirementFactory.StatsAdditionIsBiggerThenStatsAdditionRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName,
                Attributes = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "LeftAddition", Value = this.GetStatsList(this.LeftAddition)},
                    new NameValueInfo {Name = "RightAddition", Value = this.GetStatsList(this.RightAddition)}
                }
            };

            return item;
            
        }

        private string GetStatsList(IEnumerable<string> additionsList)
        {
            string result = additionsList.Aggregate(string.Empty, (current, item) => current + (item + ","));
            result = result.Remove(result.Length - 1);
            return result;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            return this.CalculateAddition(stats, this.LeftAddition) > this.CalculateAddition(stats, this.RightAddition);
        }
    }
}
