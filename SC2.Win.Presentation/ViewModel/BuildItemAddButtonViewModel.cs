using System.Linq;
using SC2.Entities;
using SC2.Entities.BuildItems;

namespace SC2.Win.Presentation.ViewModel
{
    public class BuildItemAddButtonViewModel : ViewModelBase<BuildItemEntity>
    {
        private readonly BuildItemStatistics mStats;

        public BuildItemAddButtonViewModel(BuildItemEntity model, BuildItemStatistics stats)
            : base(model)
        {
            mStats = stats;
        }

        public string BuildItemName
        {
            get
            {
                return Model.Name;
            }
        }

        public string ButtonDisplayName
        {
            get
            {
                return Model.DisplayName;
            }
        }

        public int ItemCounter
        {
            get
            {
                return mStats.GetStatValueByName(Model.Name);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return Model.OrderRequirements.All(requirement => requirement.IsRequirementSatisfied(mStats));
            }
        }
    }
}