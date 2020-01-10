using System;
using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public static class BuildItemRequirementFactory
    {
        public static string CastRequirement = "CastRequirement";
        public static string ItemExistsOrOnBuildingRequirement = "ItemExistsOrOnBuildingRequirement";
        public static string LarvaRequirement = "LarvaRequirement";
        public static string OrBuildItemRequirement = "OrBuildItemRequirement";
        public static string StatBiggerOrEqualThenStatRequirement = "StatBiggerOrEqualThenStatRequirement";
        public static string StatBiggerOrEqualThenStatWithAdditionRequirement = "StatBiggerOrEqualThenStatWithAdditionRequirement";
        public static string StatBiggerOrEqualThenValueRequirement = "StatBiggerOrEqualThenValueRequirement";
        public static string StatLessThenStatRequirement = "StatLessThenStatRequirement";
        public static string StatLessThenValueRequirement = "StatLessThenValueRequirement";
        public static string StatsAdditionIsBiggerThenStatsAdditionRequirement = "StatsAdditionIsBiggerThenStatsAdditionRequirement";
        public static string FreeHatchRequirement = "FreeHatchRequirement";
        public static string SecondsPassedRequirement = "SecondsPassedRequirement";

        public static IBuildItemRequirement ConstructRequirement(ItemWithAttributesInfo info)
        {
            if (info.Name == CastRequirement)
            {
                int requiredValue = info.ReadIntAttribute("RequiredValue").Value;

                return new CastRequirement(requiredValue);
            }

            if (info.Name == ItemExistsOrOnBuildingRequirement)
            {
                var targetItemName = info.ReadStringAttribute("TargetItemName");

                return new ItemExistsOrOnBuildingRequirement(targetItemName);
            }

            if (info.Name == LarvaRequirement)
            {
                int requiredValue = info.ReadIntAttribute("RequiredValue").Value;

                return new LarvaRequirement(requiredValue);
            }

            if (info.Name == OrBuildItemRequirement)
            {
                var left = info.ChildItems[0];
                var right = info.ChildItems[1];

                var leftReq = ConstructRequirement(left);
                var rightReq = ConstructRequirement(right);

                return new OrBuildItemRequirement(leftReq, rightReq);
            }

            if (info.Name == StatBiggerOrEqualThenStatRequirement)
            {
                var leftStatName = info.ReadStringAttribute("LeftStatName");
                var rightStatName = info.ReadStringAttribute("RightStatName");

                return new StatBiggerOrEqualThenStatRequirement(leftStatName, rightStatName);
            }

            if (info.Name == StatBiggerOrEqualThenStatWithAdditionRequirement)
            {
                var leftStatName = info.ReadStringAttribute("LeftStatName");
                var rightStatName = info.ReadStringAttribute("RightStatName");
                int additionValue = info.ReadIntAttribute("AdditionValue").Value;

                return new StatBiggerOrEqualThenStatWithAdditionRequirement(leftStatName, rightStatName, additionValue);
            }

            if (info.Name == StatBiggerOrEqualThenValueRequirement)
            {
                var targetStatName = info.ReadStringAttribute("TargetStatName");
                int value = info.ReadIntAttribute("Value").Value;

                return new StatBiggerOrEqualThenValueRequirement(targetStatName, value);
            }

            if (info.Name == StatLessThenStatRequirement)
            {
                var leftStatName = info.ReadStringAttribute("LeftStatistic");
                var rightStatName = info.ReadStringAttribute("RightStatistic");

                return new StatLessThenStatRequirement(leftStatName, rightStatName);
            }

            if (info.Name == StatLessThenValueRequirement)
            {
                var targetStatName = info.ReadStringAttribute("TargetStatName");
                int value = info.ReadIntAttribute("Value").Value;

                return new StatLessThenValueRequirement(targetStatName, value);
            }

            if (info.Name == StatsAdditionIsBiggerThenStatsAdditionRequirement)
            {
                var leftStat = info.ReadStringAttribute("LeftAddition").Split(',');
                var rightStat = info.ReadStringAttribute("RightAddition").Split(',');

                return new StatsAdditionIsBiggerThenStatsAdditionRequirement(leftStat, rightStat);
            }

            throw new ApplicationException(string.Format("Requirement '{0}' is not supported", info.Name));
        }
    }
}
