using System.Collections.Generic;
using System.Globalization;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Actions
{
    public class ChangeStatisticByStatisticAction : IBuildItemAction
    {
        public string SourceStatisticName { get; private set; }        
        public string TargetStatisticName { get; private set; }        

        public ChangeStatisticByStatisticAction(string sourceStatisticName, string targetStatisticName)
        {
            SourceStatisticName = sourceStatisticName;            
            TargetStatisticName = targetStatisticName;            
        }

        public string ActionName { get { return BuildItemActionsFactory.ChangeStatisticByStatisticAction; } }

        public void DoAction(BuildItemStatistics statistics)
        {
            var sourceValue = statistics.GetStatValueByName(this.SourceStatisticName);

            statistics.ChangeItemCountForName(this.TargetStatisticName, sourceValue);
        }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var info = new ItemWithAttributesInfo { Name = this.ActionName };

            var result = new List<NameValueInfo>
                {
                    new NameValueInfo {Name = "SourceStatisticName", Value = this.SourceStatisticName},                    
                    new NameValueInfo {Name = "TargetStatisticName", Value = this.TargetStatisticName}                    
                };

            info.Attributes = result;

            return info;
        }
    }
}