using SC2.PublicData;

namespace SC2.Entities
{
    public class SC2VersionEntity
	{
		public string AddonID { get; set; }
		public string VersionID { get; set; }
		public GlobalConstantsInfo GlobalConstants { get; set; }
		public RaceSettingsEntityDictionary RaceSettingsDictionary { get; set; }
	}
}
