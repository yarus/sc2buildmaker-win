using System;

namespace SC2.Win.Presentation.View
{
    public interface IView
    {
        event EventHandler<EventArgs> ViewShown;
        event EventHandler<EventArgs> ViewClosed; 

        void ShowNormalView();
        ModalViewResult ShowModalView();
        void CloseView();
    }
}
