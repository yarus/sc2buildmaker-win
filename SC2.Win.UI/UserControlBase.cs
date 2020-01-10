using System;
using System.Windows.Forms;
using SC2.Win.Presentation;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public partial class UserControlBase : UserControl, IView
    {
        public UserControlBase()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> ViewShown;

        public event EventHandler<EventArgs> ViewClosed;

        public void ShowNormalView()
        {
            this.Visible = true;

            if (ViewShown != null)
            {
                ViewShown(this, new EventArgs());
            }
        }

        public ModalViewResult ShowModalView()
        {
            this.Visible = true;

            if (ViewShown != null)
            {
                ViewShown(this, new EventArgs());
            }

            return ModalViewResult.Ok;
        }

        public void CloseView()
        {
            this.Visible = false;

            if (ViewClosed != null)
            {
                ViewClosed(this, new EventArgs());
            }
        }
    }
}
