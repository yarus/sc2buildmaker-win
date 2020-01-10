using System.Collections.Generic;
using System.Linq;
using SC2.PublicData;

namespace SC2.Entities
{
    public class BuildItemStatistics
    {
        private readonly Dictionary<string, int> mStatValuesDictionary;
        private readonly RaceConstantsInfo mRaceConstants;

        public BuildItemStatistics(RaceConstantsInfo raceSettings)
            : this(raceSettings, new Dictionary<string, int>())
        {
        }

        public BuildItemStatistics(RaceConstantsInfo raceSettings, Dictionary<string, int> itemCountDictionary)
        {
            this.mRaceConstants = raceSettings;
            this.mStatValuesDictionary = itemCountDictionary;
        }

        public List<KeyValuePair<string, int>> GetStatsWithKeyContains(string filter)
        {
            return this.mStatValuesDictionary.Where(p => p.Key.Contains(filter)).ToList();
        }

        public int GetStatValueByName(string name)
        {
            if (this.mStatValuesDictionary.ContainsKey(name))
            {
                return this.mStatValuesDictionary[name];
            }

            return 0;
        }

        public void RemoveStat(string name)
        {
            this.mStatValuesDictionary.Remove(name);
        }

        public void SetItemCountForName(string name, int value)
        {
            this.mStatValuesDictionary[name] = value;
        }

        public void ChangeItemCountForName(string name, int changeValue)
        {
            this.mStatValuesDictionary[name] = this.GetStatValueByName(name) + changeValue;   
        }

        public Dictionary<string, int> CloneItemsCountDictionary()
        {
            return new Dictionary<string, int>(this.mStatValuesDictionary);
        }

        public int MaximumSupply
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.MaximumSupply); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.MaximumSupply] = value; }
        }

        public int CurrentSupply
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.CurrentSupply); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.CurrentSupply] = value; }
        }

        public int WorkersOnMinerals
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.WorkersOnMinerals); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.WorkersOnMinerals] = value; }
        }

        public int WorkersOnGas
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.WorkersOnGas); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.WorkersOnGas] = value; }
        }

        public int WorkersOnWalk
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.WorkersOnWalk); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.WorkersOnWalk] = value; }
        }

        public int BasesCount
        {
            get { return this.GetStatValueByName(this.mRaceConstants.DefaultBaseBuildingName); }
            set { this.mStatValuesDictionary[this.mRaceConstants.DefaultBaseBuildingName] = value; }
        }

        public int Minerals
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.Minerals); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.Minerals] = value; }
        }

        public int Gas
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.Gas); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.Gas] = value; }
        }

        public int MilliMinerals
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.MilliMinerals); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.MilliMinerals] = value; }
        }

        public int MilliGas
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.MilliGas); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.MilliGas] = value; }
        }

        public int MilliEnergy
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.MilliEnergy); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.MilliEnergy] = value; }
        }

        public int MulesOnMinerals
        {
            get { return this.GetStatValueByName(Consts.CoreStatistics.MulesOnMinerals); }
            set { this.mStatValuesDictionary[Consts.CoreStatistics.MulesOnMinerals] = value; }
        }
    }
}