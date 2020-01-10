using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Actions
{
    public class ChangeStatisticAction : IBuildItemAction
    {
        public string TargetStatisticName { get; private set; }
        public int ChangeValue { get; private set; }
        public string LimitStatisticName { get; private set; }

        public ChangeStatisticAction(string targetStatisticName, int changeValue)
            : this(targetStatisticName, changeValue, string.Empty)
        {
        }

        public ChangeStatisticAction(string targetStatisticName, int changeValue, string limitStatisticName)
        {
            this.TargetStatisticName = targetStatisticName;
            this.ChangeValue = changeValue;
            this.LimitStatisticName = limitStatisticName;
        }

        public string ActionName { get { return BuildItemActionsFactory.ChangeStatisticAction; } }

        public void DoAction(BuildItemStatistics statistics)
        {
            int valueToAdd = this.ChangeValue;
            
            if (!string.IsNullOrEmpty(this.LimitStatisticName))
            {
                var previousValue = statistics.GetStatValueByName(this.TargetStatisticName);

                var limitStatValue = statistics.GetStatValueByName(this.LimitStatisticName);
                if (previousValue + this.ChangeValue > limitStatValue)
                {
                    valueToAdd = limitStatValue - previousValue;
                }
            }

            statistics.ChangeItemCountForName(this.TargetStatisticName, valueToAdd);
        }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var info = new ItemWithAttributesInfo {Name = this.ActionName};

            var result = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "TargetStatisticName", Value = this.TargetStatisticName},
                    new NameValueInfo {Name = "ChangeValue", Value = this.ChangeValue.ToString(CultureInfo.InvariantCulture)},
                    new NameValueInfo {Name = "LimitStatisticName", Value = this.LimitStatisticName}
                };

            info.Attributes = result;

            return info;
        }
    }
}