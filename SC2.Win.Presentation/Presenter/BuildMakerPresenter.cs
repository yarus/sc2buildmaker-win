using System;
using System.Collections.Generic;
using System.Linq;
using SC2.DataManagers;
using SC2.Entities;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildOrderProcessor;
using SC2.Win.Presentation.View;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.Presentation.Presenter
{
    public class BuildMakerPresenter : PresenterBase<IBuildMakerView>
    {
        private readonly EditBuildInfoPresenter mEditBuildInfoPresenter;
        private readonly IEditBuildInfoView mEditBuildInfoView;

        private readonly AddBuildItemListPresenter mAddItemPresenter;
        private readonly IAddBuildItemListView mAddItemView;

        private BuildOrderProcessorConfiguration mConfig;
        private BuildOrderProcessor mBuildManager;

        private readonly IBuildOrdersManager mBuildOrdersManager;

        public BuildMakerPresenter(IBuildMakerView view, IAddBuildItemListView addItemView, IEditBuildInfoView editBuildInfo, BuildOrderProcessorConfiguration config, IBuildOrdersManager boManager)
            : base(view)
        {
            mConfig = config;

            mBuildOrdersManager = boManager;

            mAddItemView = addItemView;
            mAddItemPresenter = new AddBuildItemListPresenter(mAddItemView);

            mEditBuildInfoView = editBuildInfo;
            mEditBuildInfoPresenter = new EditBuildInfoPresenter(mEditBuildInfoView, mBuildOrdersManager);

            mBuildManager = new BuildOrderProcessor(mConfig);

            view.ClearBuild += ViewClearBuild;
            view.UndoItem += ViewUndoItem;
            view.SaveBuild += ViewSaveBuild;
            view.AddItemRequested += ViewAddItemRequested;
            view.BackRequested += ViewBackRequested;

            mAddItemPresenter.ItemSelected += AddItemPresenterItemSelected;

            mEditBuildInfoPresenter.BuildSaved += EditBuildInfoPresenterBuildSaved;
        }

        void EditBuildInfoPresenterBuildSaved(object sender, BuildOrderEntity e)
        {
            mEditBuildInfoPresenter.CloseView();

            mBuildManager.LoadBuildDataFromEntity(e);

            UpdateView();
        }

        void ViewBackRequested(object sender, EventArgs e)
        {
            if (BackRequested != null)
            {
                BackRequested(this, new EventArgs());
            }
        }

        void AddItemPresenterItemSelected(object sender, string e)
        {
            mBuildManager.AddBuildItem(e);

            UpdateView();
        }

        void ViewAddItemRequested(object sender, BuildItemTypeEnum e)
        {
            mAddItemPresenter.ShowBuildItems(
                mConfig.BuildItemsDictionary
                .Clone()
                .Values
                .Where(p => p.ItemType == e && p.Name != Consts.DefaultStateItemName), mBuildManager.CurrentStatistics);

            mAddItemView.ShowModalView();
        }
        
        public event EventHandler BackRequested;

        void ViewSaveBuild(object sender, EventArgs e)
        {
            mEditBuildInfoPresenter.LoadBuildEntity(mBuildManager.CurrentBuildOrder.GenerateBuildOrderEntity());
            mEditBuildInfoPresenter.ShowModalView();
        }

        void ViewClearBuild(object sender, EventArgs e)
        {
            var boEntity = mBuildManager.CurrentBuildOrder.GenerateBuildOrderEntity();
            boEntity.BuildOrderItems = new List<string>();

            mBuildManager.LoadBuildOrder(boEntity);

            UpdateView();
        }

        void ViewUndoItem(object sender, EventArgs e)
        {
            mBuildManager.UndoLastBuildItem();

            UpdateView();
        }

        public void LoadBuildOrder(BuildOrderEntity bo, BuildOrderProcessorConfiguration config)
        {
            mConfig = config;

            mBuildManager = new BuildOrderProcessor(mConfig);

            mBuildManager.LoadBuildOrder(bo);

            UpdateView();
        }
        
        private void UpdateView()
        {
            View.ViewModel = new BuildMakerViewModel(mBuildManager.CurrentBuildOrder, mConfig);
        }
    }
}
