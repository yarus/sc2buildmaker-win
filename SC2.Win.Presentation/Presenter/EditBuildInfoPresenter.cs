using System;
using SC2.DataManagers;
using SC2.Entities;
using SC2.Win.Presentation.View;

namespace SC2.Win.Presentation.Presenter
{
    public class EditBuildInfoPresenter : PresenterBase<IEditBuildInfoView>
    {
        private readonly IBuildOrdersManager mBuildOrdersProvider;

        public EditBuildInfoPresenter(IEditBuildInfoView view, IBuildOrdersManager boProvider)
            : base(view)
        {
            mBuildOrdersProvider = boProvider;

            view.BackRequested += ViewBackRequested;
            view.SaveBuildOrder += ViewSaveBuildOrder;
        }

        public void LoadBuildEntity(BuildOrderEntity boInfo)
        {
            View.BuildOrderEntity = boInfo;
        }

        void ViewSaveBuildOrder(object sender, EventArgs e)
        {
            var bo = View.BuildOrderEntity;

            mBuildOrdersProvider.SaveBuildOrder(bo);

            if (BuildSaved != null)
            {
                BuildSaved(this, bo);
            }
        }

        void ViewBackRequested(object sender, EventArgs e)
        {
            View.CloseView();
        }

        public event EventHandler<BuildOrderEntity> BuildSaved;
    }
}
