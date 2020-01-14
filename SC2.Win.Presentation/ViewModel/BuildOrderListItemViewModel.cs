using SC2.Entities;

namespace SC2.Win.Presentation.ViewModel
{
    public class BuildOrderListItemViewModel : ViewModelBase<BuildOrderEntity>
    {
        public BuildOrderListItemViewModel(BuildOrderEntity buildOrderEntity)
            : base(buildOrderEntity)
        {
            
        }

        public string MatchupBackgroundImagePath
        {
            get { return ImageProvider.GetMatchupBackgroundImagePath(); }
        }

        public string MatchupLabel
        {
            get { return GetRaceLetter(Model.Race) + "v" + GetRaceLetter(Model.VsRace); }
        }
        
        public string BuildName
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }

        public string BuildDescription
        {
            get { return Model.Description; }
            set { Model.Description = value; }
        }

        public string SC2VersionID
        {
            get { return Model.SC2VersionID; }
            set { Model.SC2VersionID = value; }
        }

        private string GetRaceLetter(RaceEnum race)
        {
            switch (race)
            {
                case RaceEnum.Zerg:
                    return "Z";
                case RaceEnum.Terran:
                    return "T";
                case RaceEnum.Protoss:
                    return "P";
            }

            return "X";
        }
    }
}
