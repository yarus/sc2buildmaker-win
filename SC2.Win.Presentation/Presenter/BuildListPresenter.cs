using System;
using SC2.DataManagers;
using SC2.Entities;
using SC2.Win.Presentation.View;

namespace SC2.Win.Presentation.Presenter
{
    public class BuildListPresenter : PresenterBase<IBuildListView>
    {
        private readonly IBuildOrdersManager mBuildOrdersManager;

        public BuildListPresenter(IBuildListView view, IBuildOrdersManager boProvider)
            : base(view)
        {
            mBuildOrdersManager = boProvider;

            view.NewBuild += NewBuildCommand;
            view.SearchBuild += SearchCommand;
            view.SelectBuild += SelectBuildCommand;
            view.SortBuildList += SortCommand;
        }

        public void LoadBuildList()
        {
            View.BuildOrderList = mBuildOrdersManager.GetBuildOrders();
        }

        #region Command Handlers

        void NewBuildCommand(object sender, EventArgs e)
        {
            if (NewBuild != null)
            {
                NewBuild(this, new EventArgs());
            }
        }

        void SortCommand(object sender, EventArgs e)
        {

        }

        void SelectBuildCommand(object sender, BuildOrderEntity bo)
        {
            if (SelectBuild != null)
            {
                SelectBuild(this, bo);
            }
        }

        void SearchCommand(object sender, EventArgs e)
        {

        }

        #endregion

        public event EventHandler<EventArgs> NewBuild;
        public event EventHandler<BuildOrderEntity> SelectBuild;
    }
}
