using System;
using System.Collections.Generic;

namespace SC2.PublicData
{
    [Serializable]
	public class SC2VersionInfo
	{
		public string AddonID { get; set; }
		public string VersionID { get; set; }

		public GlobalConstantsInfo GlobalSettings { get; set; }

		public List<RaceSettingsInfo> RaceSettingsList { get; set; }

		public SC2VersionInfo()
		{
			this.RaceSettingsList = new List<RaceSettingsInfo>();
		}
	}
}
