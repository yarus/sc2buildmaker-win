using SC2.Entities.BuildItems;
using SC2.PublicData;

namespace SC2.Entities.BuildOrderProcessor
{
    public class BuildOrderProcessorConfiguration
    {
        public string SC2VersionID { get; set; }

        public RaceEnum Race { get; set; }

        public GlobalConstantsInfo GlobalConstants { get; set; }

        public RaceConstantsInfo RaceConstants { get; set; }

        public BuildItemsDictionary BuildItemsDictionary { get; set; }

        public BuildManagerModulesList BuildManagerModules { get; set; }
    }
}
