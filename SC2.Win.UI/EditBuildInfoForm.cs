using System;
using SC2.Entities;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public partial class EditBuildInfoForm : FormBase, IEditBuildInfoView
    {
        public EditBuildInfoForm()
        {
            InitializeComponent();
        }

        private BuildOrderEntity mBuildOrderEntity;
        public BuildOrderEntity BuildOrderEntity
        {
            get
            {
                var bo = new BuildOrderEntity
                {
                    Name = tbBuildName.Text,
                    Description = tbDescription.Text,
                    Race = mBuildOrderEntity.Race,
                    SC2VersionID = mBuildOrderEntity.SC2VersionID,
                    VsRace = GetRaceFromRadio(),
                    BuildOrderItems = mBuildOrderEntity.BuildOrderItems
                };

                return bo;
            }
            set
            {
                mBuildOrderEntity = value;
                ShowBuildInfo();
            }
        }

        private void ShowBuildInfo()
        {
            tbVersionID.Text = mBuildOrderEntity.SC2VersionID;
            tbBuildName.Text = mBuildOrderEntity.Name;
            tbDescription.Text = mBuildOrderEntity.Description;

            SetRadioChecked(mBuildOrderEntity.VsRace);
        }

        private void SetRadioChecked(RaceEnum race)
        {
            switch(race)
            {
                case RaceEnum.Terran:
                    rbTerran.Checked = true;
                    break;
                case RaceEnum.Zerg:
                    rbZerg.Checked = true;
                    break;
                case RaceEnum.Protoss:
                    rbProtoss.Checked = true;
                    break;
            }
        }

        private RaceEnum GetRaceFromRadio()
        {
            if (rbTerran.Checked) return RaceEnum.Terran;

            if (rbProtoss.Checked) return RaceEnum.Protoss;

            if (rbZerg.Checked) return RaceEnum.Zerg;
            
            return RaceEnum.NotDefined;
        }

        public event EventHandler SaveBuildOrder;

        public event EventHandler BackRequested;

        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (BackRequested != null)
            {
                BackRequested(this, new EventArgs());
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (SaveBuildOrder != null)
            {
                SaveBuildOrder(this, new EventArgs());
            }
        }
    }
}
