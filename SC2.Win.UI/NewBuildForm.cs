using System;
using System.Collections.Generic;
using SC2.Entities;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public partial class NewBuildForm : FormBase, INewBuildView
    {
        public NewBuildForm()
        {
            InitializeComponent();
        }

        public IEnumerable<string> VersionIDs
        {
            set
            {
                cbVersions.DataSource = value;
            }
        }

        public string SelectedVersion
        {
            get
            {
                return cbVersions.SelectedItem.ToString();
            }
        }

        public event EventHandler BackRequested;

        public event EventHandler<RaceEnum> SelectionDone;

        private void OnSelectionDone(RaceEnum race)
        {
            if (SelectionDone != null)
            {
                SelectionDone(this, race);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (BackRequested != null)
            {
                BackRequested(this, new EventArgs());
            }
        }

        private void btnTerran_Click(object sender, EventArgs e)
        {
            OnSelectionDone(RaceEnum.Terran);
        }

        private void btnZerg_Click(object sender, EventArgs e)
        {
            OnSelectionDone(RaceEnum.Zerg);
        }

        private void btnProtoss_Click(object sender, EventArgs e)
        {
            this.OnSelectionDone(RaceEnum.Protoss);
        }
    }
}
