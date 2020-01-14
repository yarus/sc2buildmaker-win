using System;
using SC2.Entities;
using SC2.Win.Presentation.View;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.Presentation.Presenter
{
    public class BuildListItemControlPresenter : PresenterBase<IBuildListItemControlView>
    {
        public BuildListItemControlPresenter(IBuildListItemControlView view) : base(view)
        {
            view.ItemClicked += ViewItemClicked;
        }

        void ViewItemClicked(object sender, BuildOrderEntity e)
        {
            if (BuildSelected != null)
            {
                BuildSelected(this, e);
            }
        }

        public void LoadBuildOrderListItem(BuildOrderEntity bo)
        {
            View.BuildOrder = new BuildOrderListItemViewModel(bo);
        }

        public event EventHandler<BuildOrderEntity> BuildSelected;
    }
}
