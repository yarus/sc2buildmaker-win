using System;
using System.Windows.Forms;
using SC2.Win.Presentation;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public class FormBase : Form, IView
    {
        public event EventHandler<EventArgs> ViewShown;
        public event EventHandler<EventArgs> ViewClosed;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (ViewShown != null)
            {
                ViewShown(this, new EventArgs());
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (ViewClosed != null)
            {
                ViewClosed(this, new EventArgs());
            }
        }

        public void ShowNormalView()
        {
            Show();
        }

        public ModalViewResult ShowModalView()
        {
            var dialogResult = ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                return ModalViewResult.Ok;
            }

            return ModalViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
        }
    }
}
