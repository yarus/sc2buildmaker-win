using System.Collections.Generic;

namespace SC2.Entities
{
    public class RaceSettingsEntityDictionary
    {
        private readonly Dictionary<RaceEnum, RaceSettingsEntity> mRaceSettingsDictionary;

        public RaceSettingsEntityDictionary()
        {
            this.mRaceSettingsDictionary = new Dictionary<RaceEnum, RaceSettingsEntity>();
        }

        public IEnumerable<RaceSettingsEntity> GetRaceSettingsList()
        {
            return this.mRaceSettingsDictionary.Values;
        }

        public RaceSettingsEntity GetRaceSettings(RaceEnum race)
        {
            return this.mRaceSettingsDictionary[race];
        }

        public void AddRaceSettings(RaceSettingsEntity settings)
        {
            this.mRaceSettingsDictionary[settings.Race] = settings;
        }
    }
}
