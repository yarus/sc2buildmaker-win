using System.Collections.Generic;
using System.Linq;
using SC2.Entities;
using SC2.Entities.BuildOrderProcessor;

namespace SC2.Win.Presentation.ViewModel
{
    public class BuildMakerViewModel : ViewModelBase<BuildOrderProcessorData>
    {
        private BuildOrderProcessorConfiguration mConfig;

        public BuildMakerViewModel(BuildOrderProcessorData model, BuildOrderProcessorConfiguration config)
            : base(model)
        {
            mConfig = config;
        }

        public string BuildName
        {
            get
            {
                return Model.Name;
            }
        }

        public string SC2VersionID 
        { 
            get
            {
                return Model.SC2VersionID;
            }
        }

        public RaceEnum Race
        {
            get
            {
                return Model.Race;
            }
        }

        public BuildItemStatistics CurrentStatistics
        {
            get
            {
                return Model.LastBuildItem.StatisticsProvider;
            }
        }

        private IEnumerable<BuildOrderItemViewModel> mBuildItems;
        public IEnumerable<BuildOrderItemViewModel> BuildItems
        {
            get
            {
                if (mBuildItems == null)
                {
                    mBuildItems = GenerateBuildItemsViewModel();
                }

                return mBuildItems;
            }
        }

        private IEnumerable<BuildOrderItemViewModel> GenerateBuildItemsViewModel()
        {
            var buildItems = Model.GetBuildOrderItemsClone();

            var viewModel = from item in buildItems
                            select new BuildOrderItemViewModel(item, mConfig.BuildItemsDictionary.GetItem(item.ItemName));

            return viewModel;
        }
    }
}
