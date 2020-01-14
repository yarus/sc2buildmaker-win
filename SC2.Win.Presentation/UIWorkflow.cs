using System;
using SC2.DataManagers;
using SC2.Entities;
using SC2.Entities.BuildOrderProcessor;
using SC2.Win.Presentation.Presenter;
using SC2.Win.Presentation.View;

namespace SC2.Win.Presentation
{
    public class UIWorkflow
    {
        private IViewFactory mViewFactory;
        private IDataManagersConfigurator mManagersConfigurator;

        private IPresenter mCurrentPresenter;

        public UIWorkflow(IDataManagersConfigurator managersConfigurator, IViewFactory viewFactory)
        {
            mManagersConfigurator = managersConfigurator;
            mViewFactory = viewFactory;
        }

        public void ShowMainForm()
        {
            var presenter = new BuildListPresenter(mViewFactory.CreateView<IBuildListView>(), mManagersConfigurator.GetBuildOrdersManager());

            SetCurrentPresenter(presenter, presenter.View);

            presenter.LoadBuildList();

            presenter.ShowNormalView();
        }

        public event EventHandler<IView> CurrentViewChanged;

        #region Common Methods

        private void SetCurrentPresenter(IPresenter presenter, IView view)
        {
            OnCurrentViewChanged(view);

            if (mCurrentPresenter != null)
            {
                mCurrentPresenter.CloseView();   
            }

            mCurrentPresenter = presenter;

            AdjustPresenterEventHandlers(mCurrentPresenter);
        }

        private void OnCurrentViewChanged(IView view)
        {
            if (CurrentViewChanged != null)
            {
                CurrentViewChanged(this, view);
            }
        }

        private void AdjustPresenterEventHandlers(IPresenter presenter)
        {
            var buildList = presenter as BuildListPresenter;
            if (buildList != null)
            {
                buildList.NewBuild += OnNewBuildRequested;
                buildList.SelectBuild += OnSelectBuild;
                return;
            }

            var buildMaker = presenter as BuildMakerPresenter;
            if (buildMaker != null)
            {
                buildMaker.BackRequested += OnBackRequested;
                return;
            }

            var newBuild = presenter as NewBuildPresenter;
            if (newBuild != null)
            {
                newBuild.BackRequested += OnNewBuildBackRequested;
                newBuild.CreateNewBuildRequested += OnCreateNewBuildRequested;
            }
        }

        private BuildOrderProcessorConfiguration GenerateBuildManagerConfig(string versionID, RaceEnum race)
        {
            var version = mManagersConfigurator.GetSC2VersionsManager().GetVersion(versionID);

            var raceSettings = version.RaceSettingsDictionary.GetRaceSettings(race);

            var boManagerConfig = new BuildOrderProcessorConfiguration
                {
                    BuildItemsDictionary = raceSettings.ItemsDictionary,
                    BuildManagerModules = raceSettings.Modules,
                    GlobalConstants = version.GlobalConstants,
                    Race = race,
                    RaceConstants = raceSettings.Constants,
                    SC2VersionID = version.VersionID
                };

            return boManagerConfig;
        }

        #endregion

        #region Command Handlers

        void OnBackRequested(object sender, EventArgs e)
        {
            var presenter = new BuildListPresenter(mViewFactory.CreateView<IBuildListView>(), mManagersConfigurator.GetBuildOrdersManager());

            SetCurrentPresenter(presenter, presenter.View);

            presenter.LoadBuildList();
            presenter.ShowNormalView();
        }

        private void OnNewBuildRequested(object sender, EventArgs e)
        {
            var presenter = new NewBuildPresenter(mViewFactory.CreateView<INewBuildView>(), mManagersConfigurator.GetSC2VersionsManager());

            SetCurrentPresenter(presenter, presenter.View);

            presenter.ShowNormalView();
        }

        void OnCreateNewBuildRequested(object sender, BuildOrderEntity e)
        {
            var boManagerConfig = GenerateBuildManagerConfig(e.SC2VersionID, e.Race);

            var presenter = new BuildMakerPresenter(mViewFactory.CreateView<IBuildMakerView>(), mViewFactory.CreateView<IAddBuildItemListView>(), mViewFactory.CreateView<IEditBuildInfoView>(), boManagerConfig, mManagersConfigurator.GetBuildOrdersManager());
            presenter.LoadBuildOrder(e, boManagerConfig);

            SetCurrentPresenter(presenter, presenter.View);

            presenter.ShowNormalView();
        }

        void OnNewBuildBackRequested(object sender, EventArgs e)
        {
            var presenter = new BuildListPresenter(mViewFactory.CreateView<IBuildListView>(), mManagersConfigurator.GetBuildOrdersManager());

            SetCurrentPresenter(presenter, presenter.View);

            presenter.LoadBuildList();
            presenter.ShowNormalView();
        }

        private void OnSelectBuild(object sender, BuildOrderEntity buildOrderEntity)
        {
            var boManagerConfig = GenerateBuildManagerConfig(buildOrderEntity.SC2VersionID, buildOrderEntity.Race);

            var presenter = new BuildMakerPresenter(mViewFactory.CreateView<IBuildMakerView>(), mViewFactory.CreateView<IAddBuildItemListView>(), mViewFactory.CreateView<IEditBuildInfoView>(), boManagerConfig, mManagersConfigurator.GetBuildOrdersManager());

            SetCurrentPresenter(presenter, presenter.View);

            presenter.LoadBuildOrder(buildOrderEntity, boManagerConfig);
            presenter.ShowNormalView();
            
        }

        #endregion
    }
}
