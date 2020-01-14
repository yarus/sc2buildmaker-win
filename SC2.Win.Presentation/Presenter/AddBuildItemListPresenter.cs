using System;
using System.Collections.Generic;
using System.Linq;
using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Win.Presentation.View;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.Presentation.Presenter
{
    public class AddBuildItemListPresenter : PresenterBase<IAddBuildItemListView>
    {
        public AddBuildItemListPresenter(IAddBuildItemListView view) : base(view)
        {
            view.ItemSelected += ViewItemSelected;
            view.Cancel += ViewCancel;
        }

        public void ShowBuildItems(IEnumerable<BuildItemEntity> buildItems, BuildItemStatistics stats)
        {
            var buttonsList = buildItems.Select(buildItem => new BuildItemAddButtonViewModel(buildItem, stats)).ToList();

            View.BuildItems = buttonsList;
        }

        void ViewCancel(object sender, EventArgs e)
        {
            View.CloseView();
        }

        void ViewItemSelected(object sender, string e)
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, e);
            }

            View.CloseView();
        }

        public event EventHandler<string> ItemSelected;
    }
}
