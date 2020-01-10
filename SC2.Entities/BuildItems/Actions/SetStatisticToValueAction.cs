using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Actions
{
    public class SetStatisticToValueAction : IBuildItemAction
    {
        public string TargetStatisticName { get; private set; }
        public int TargetValue { get; private set; }

        public SetStatisticToValueAction(string targetStatisticName, int targetValue)
        {
            TargetStatisticName = targetStatisticName;
            TargetValue = targetValue;
        }

        public string ActionName { get { return BuildItemActionsFactory.SetStatisticToValueAction; } }

        public void DoAction(BuildItemStatistics statistics)
        {
            statistics.SetItemCountForName(this.TargetStatisticName, this.TargetValue);
        }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var info = new ItemWithAttributesInfo { Name = this.ActionName };

            var result = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "TargetStatisticName", Value = this.TargetStatisticName},
                    new NameValueInfo {Name = "TargetValue", Value = this.TargetValue.ToString(CultureInfo.InvariantCulture)},               
                };

            info.Attributes = result;

            return info;
        }
    }
}