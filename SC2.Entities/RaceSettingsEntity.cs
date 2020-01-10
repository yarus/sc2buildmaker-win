using SC2.Entities.BuildItems;
using SC2.PublicData;

namespace SC2.Entities
{
    public class RaceSettingsEntity
    {
        public RaceEnum Race { get; set; }
        public RaceConstantsInfo Constants { get; set; }
        public BuildItemsDictionary ItemsDictionary { get; set; }
        public BuildManagerModulesList Modules { get; set; }

        public RaceSettingsEntity()
        {
            this.ItemsDictionary = new BuildItemsDictionary();
            this.Modules = new BuildManagerModulesList();
        }
    }
}
