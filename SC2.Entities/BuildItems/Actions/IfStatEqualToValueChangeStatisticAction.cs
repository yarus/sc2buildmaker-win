using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Actions
{
    public class IfStatEqualToValueChangeStatisticAction : IBuildItemAction
    {
        public string CompareStatisticName { get; private set; }
        public int CompareValue { get; private set; }
        public string TargetStatisticName { get; private set; }
        public int ChangeValue { get; private set; }

        public IfStatEqualToValueChangeStatisticAction(string compareStatisticName, int compareValue, string targetStatisticName, int changeValue)
        {
            CompareStatisticName = compareStatisticName;
            CompareValue = compareValue;
            TargetStatisticName = targetStatisticName;
            ChangeValue = changeValue;
        }

        public string ActionName { get { return BuildItemActionsFactory.IfStatEqualToValueChangeStatisticAction; } }

        public void DoAction(BuildItemStatistics statistics)
        {
            var currentCompareValue = statistics.GetStatValueByName(this.CompareStatisticName);
            if (currentCompareValue == CompareValue)
            {
                statistics.ChangeItemCountForName(this.TargetStatisticName, this.ChangeValue);
            }
        }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var info = new ItemWithAttributesInfo { Name = this.ActionName };

            var result = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "CompareStatisticName", Value = this.CompareStatisticName},
                    new NameValueInfo {Name = "CompareValue", Value = this.CompareValue.ToString(CultureInfo.InvariantCulture)},
                    new NameValueInfo {Name = "TargetStatisticName", Value = this.TargetStatisticName},
                    new NameValueInfo {Name = "ChangeValue", Value = this.ChangeValue.ToString(CultureInfo.InvariantCulture)}
                };

            info.Attributes = result;

            return info;
        }
    }
}