using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SC2.Entities.BuildItems;
using SC2.Win.Presentation.View;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.UI
{
    public partial class BuildMaker : FormBase, IBuildMakerView
    {
        public BuildMaker()
        {
            InitializeComponent();

            gvResult.AutoGenerateColumns = false;
            gvResult.RowPrePaint += GvResultRowPrePaint;
        }

        private bool mIsLoaded;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            mIsLoaded = true;

            UpdateView();
        }

        #region UI databind methods

        private void FillResourcesPanel()
        {
            var stats = mViewModel.CurrentStatistics;

            var bldr = new StringBuilder();

            var resourceStatistics = new List<string> { "Minerals", "Gas", "TotalCasts", "CurrentSupply", "MaximumSupply" };

            foreach (var stat in stats.CloneItemsCountDictionary().Where(p => resourceStatistics.Contains(p.Key)))
            {
                bldr.Append(string.Format("{0}:{1} | ", stat.Key, stat.Value));
            }

            var resourceString = bldr.ToString();

            tbResources.Text = resourceString.Remove(resourceString.Length - 3);
        }

        private void PrintBuildData()
        {
            gvResult.DataSource = mViewModel.BuildItems.ToList();

            if (gvResult.Rows.Count > 0)
            {
                gvResult.FirstDisplayedScrollingRowIndex = gvResult.Rows.Count - 1;   
            }
        }

        private void UpdateView()
        {
            PrintBuildData();
            FillResourcesPanel();

            lblBuildName.Text = mViewModel.BuildName;
        }

        #endregion

        #region EventHandlers

        private void BtnClearClick(object sender, EventArgs e)
        {
            if (ClearBuild != null)
            {
                ClearBuild(this, new EventArgs());
            }
        }

        private void BtnUndoClick(object sender, EventArgs e)
        {
            if (UndoItem != null)
            {
                UndoItem(this, new EventArgs());
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (SaveBuild != null)
            {
                SaveBuild(this, new EventArgs());
            }
        }

        #endregion

        #region IBuildMakerView implementation

        private BuildMakerViewModel mViewModel;

        public BuildMakerViewModel ViewModel
        {
            set
            {
                mViewModel = value;

                if (mIsLoaded)
                {
                    UpdateView();
                }
            }
        }

        public event EventHandler SaveBuild;

        public event EventHandler UndoItem;

        public event EventHandler ClearBuild;

        public event EventHandler BackRequested;

        public event EventHandler<BuildItemTypeEnum> AddItemRequested;

        #endregion

        #region Common Methods

        private void OnAddItemRequested(BuildItemTypeEnum itemType)
        {
            if (AddItemRequested != null)
            {
                AddItemRequested(this, itemType);
            }
        }

        private void GvResultRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = gvResult.Rows[e.RowIndex];
            var item = row.DataBoundItem as BuildOrderItemViewModel;
            if (item != null) row.DefaultCellStyle.BackColor = item.ItemColor;
        }

        #endregion

        #region UI Event Handlers

        private void BtnAddUnitClick(object sender, EventArgs e)
        {
            OnAddItemRequested(BuildItemTypeEnum.Unit);
        }

        private void BtnAddBuildingClick(object sender, EventArgs e)
        {
            OnAddItemRequested(BuildItemTypeEnum.Building);
        }

        private void BtnAddUpgradeClick(object sender, EventArgs e)
        {
            OnAddItemRequested(BuildItemTypeEnum.Upgrade);
        }

        private void BtnAddSpecialClick(object sender, EventArgs e)
        {
            OnAddItemRequested(BuildItemTypeEnum.Special);
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            if (BackRequested != null)
            {
                BackRequested(this, new EventArgs());
            }
        }

        #endregion
    }
}
