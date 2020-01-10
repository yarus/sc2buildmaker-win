using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SC2.Win.Presentation.View;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.UI
{
    public partial class AddBuildItemList : FormBase, IAddBuildItemListView
    {
        public AddBuildItemList()
        {
            InitializeComponent();

            pnlBuildItems.VerticalScroll.Visible = true;
        }

        private IEnumerable<BuildItemAddButtonViewModel> mBuildItems; 

        public IEnumerable<BuildItemAddButtonViewModel> BuildItems
        {
            set
            {
                mBuildItems = value;

                pnlBuildItems.Controls.Clear();

                foreach (var item in mBuildItems)
                {
                    var button = new Button
                    {
                        Name = item.BuildItemName,
                        Height = 40,
                        Width = 65,
                        Enabled = item.IsEnabled,
                        Text = string.Format("{0} ({1})", item.ButtonDisplayName, item.ItemCounter)
                    };

                    button.Click += ButtonOnClick;

                    pnlBuildItems.Controls.Add(button);
                }
            }
        }

        public event EventHandler<string> ItemSelected;

        public event EventHandler Cancel;

        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                DialogResult = DialogResult.Cancel;

                Cancel(this, new EventArgs());
            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (ItemSelected != null)
            {
                var btn = sender as Button;
                if (btn != null)
                {
                    DialogResult = DialogResult.OK;

                    ItemSelected(this, btn.Name);
                }
            }
        }
    }
}
