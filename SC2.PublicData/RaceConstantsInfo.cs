using System;

namespace SC2.PublicData
{
    [Serializable]
    public class RaceConstantsInfo
    {
        public string DefaultBaseBuildingName { get; set; }

        public string EnergyGeneratorBuildItemName { get; set; }

        public int EnergyCastGenerateTime { get; set; }

        public int EnergyCastLimitPerEnergyGenerator { get; set; }

        public int EnergyCastCountForNewEnergyGenerator { get; set; }
    }
}
