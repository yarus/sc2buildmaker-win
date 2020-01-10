using System;
using System.Windows.Forms;
using SC2.Entities;
using SC2.Win.Presentation.View;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.UI
{
    public partial class BuildListItemControl : UserControlBase, IBuildListItemControlView
    {
        private BuildOrderListItemViewModel mBuildOrder;
        public BuildOrderListItemViewModel BuildOrder
        {
            get { return mBuildOrder; }
            set 
            {
                mBuildOrder = value;

                pbImage.ImageLocation = mBuildOrder.MatchupBackgroundImagePath;
                lblBuildName.Text = mBuildOrder.BuildName;
                lblDescription.Text = mBuildOrder.BuildDescription;
                lblVersion.Text = mBuildOrder.SC2VersionID;
            }
        }

        public BuildListItemControl()
        {
            InitializeComponent();

            foreach (var control in this.Controls)
            {
                var ctrl = control as Control;

                if (ctrl != null)
                {
                    ctrl.Click += FormControlClick;
                }
            }
        }

        void FormControlClick(object sender, EventArgs e)
        {
            if (ItemClicked != null)
            {
                ItemClicked(this, mBuildOrder.Model);
            }
        }

        private void BuildListItemControlClick(object sender, EventArgs e)
        {
            if (ItemClicked != null)
            {
                ItemClicked(this, mBuildOrder.Model);
            }
        }

        public event EventHandler<BuildOrderEntity> ItemClicked;
    }
}
