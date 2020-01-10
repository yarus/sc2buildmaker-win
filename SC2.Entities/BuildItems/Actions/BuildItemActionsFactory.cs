using System;
using System.Linq;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Actions
{
    public static class BuildItemActionsFactory
    {
        public static string ChangeStatisticAction = "ChangeStatisticAction";
        public static string IfStatEqualToValueChangeStatisticAction = "IfStatEqualToValueChangeStatisticAction";
        public static string ChangeStatisticByStatisticAction = "ChangeStatisticByStatisticAction";
        public static string SetStatisticToValueAction = "SetStatisticToValueAction";

        public static IBuildItemAction ConstructAction(ItemWithAttributesInfo info)
        {
            if (info.Name == ChangeStatisticAction)
            {
                string targetStatName = info.Attributes.First(p => p.Name == "TargetStatisticName").Value;
                int changeValue = Convert.ToInt32(info.Attributes.First(p => p.Name == "ChangeValue").Value);
                string limitStatisticName = info.Attributes.First(p => p.Name == "LimitStatisticName").Value;

                var result = new ChangeStatisticAction(targetStatName, changeValue, limitStatisticName);

                return result;
            }

            if (info.Name == IfStatEqualToValueChangeStatisticAction)
            {
                string compareStatisticName = info.Attributes.First(p => p.Name == "CompareStatisticName").Value;
                int compareValue = Convert.ToInt32(info.Attributes.First(p => p.Name == "CompareValue").Value);
                string targetStatName = info.Attributes.First(p => p.Name == "TargetStatisticName").Value;
                int changeValue = Convert.ToInt32(info.Attributes.First(p => p.Name == "ChangeValue").Value);

                var result = new IfStatEqualToValueChangeStatisticAction(compareStatisticName, compareValue, targetStatName, changeValue);

                return result;
            }

            if (info.Name == ChangeStatisticByStatisticAction)
            {
                string sourceStatisticName = info.Attributes.First(p => p.Name == "SourceStatisticName").Value;                
                string targetStatName = info.Attributes.First(p => p.Name == "TargetStatisticName").Value;

                var result = new ChangeStatisticByStatisticAction(sourceStatisticName, targetStatName);

                return result;
            }

            if (info.Name == SetStatisticToValueAction)
            {
                string targetStatisticName = info.Attributes.First(p => p.Name == "TargetStatisticName").Value;
                int targetValue = Convert.ToInt32(info.Attributes.First(p => p.Name == "TargetValue").Value);

                var result = new SetStatisticToValueAction(targetStatisticName, targetValue);

                return result;
            }

            throw new ApplicationException(string.Format("Action '{0}' is not supported", info.Name));
        }
    }
}
