using System;
using System.Collections.Generic;

namespace SC2.PublicData
{
    [Serializable]
    public class RaceSettingsInfo
    {
        public string Race { get; set; }
        public RaceConstantsInfo Constants { get; set; }
        public List<BuildItemInfo> BuildItems { get; set; }
        public List<string> RaceModules { get; set; }

        public RaceSettingsInfo()
        {
            this.BuildItems = new List<BuildItemInfo>();
            this.RaceModules = new List<string>();
        }
    }
}