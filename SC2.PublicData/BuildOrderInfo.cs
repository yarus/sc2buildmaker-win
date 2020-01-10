using System;
using System.Collections.Generic;

namespace SC2.PublicData
{
    [Serializable]
    public class BuildOrderInfo
    {
        public string Name { get; set; }
        public string SC2VersionID { get; set; }
		public string AddonID { get; set; }
        public string Description { get; set; }
        public string Race { get; set; }
        public string VsRace { get; set; }
        public List<string> BuildOrderItems { get; set; }

        public DateTime AddedDate { get; set; }

        public BuildOrderInfo()
        {
            this.BuildOrderItems = new List<string>();
        }
    }
}