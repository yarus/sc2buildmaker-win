using System;
using System.Collections.Generic;
using SC2.Entities;
using SC2.Win.Presentation.Presenter;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public partial class BuildList : FormBase, IBuildListView
    {
        public BuildList()
        {
            InitializeComponent();
        }
        
        public IEnumerable<BuildOrderEntity> BuildOrderList
        {
            set
            {
                pnlBuildOrders.Controls.Clear();

                foreach (var bo in value)
                {
                    var viewControl = new BuildListItemControl();
                    var presenter = new BuildListItemControlPresenter(viewControl);
                    presenter.LoadBuildOrderListItem(bo);
                    presenter.ShowNormalView();
                    viewControl.ItemClicked += ViewControlItemClicked;

                    pnlBuildOrders.Controls.Add(viewControl);
                }
            }
        }

        void ViewControlItemClicked(object sender, BuildOrderEntity e)
        {
            if (SelectBuild != null)
            {
                SelectBuild(this, e);
            }
        }

        #region View events

        public event EventHandler<EventArgs> NewBuild;
        public event EventHandler<BuildOrderEntity> SelectBuild;
        public event EventHandler<EventArgs> SortBuildList;
        public event EventHandler<EventArgs> SearchBuild;

        #endregion

        private void BtnNewClick(object sender, EventArgs e)
        {
            if (NewBuild != null)
            {
                NewBuild(this, new EventArgs());
            }
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            CloseView();
        }
    }
}
