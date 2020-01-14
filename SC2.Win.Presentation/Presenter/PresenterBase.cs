using SC2.Win.Presentation.View;

namespace SC2.Win.Presentation.Presenter
{
    public class PresenterBase<T> : IPresenter where T : class, IView
    {
        public PresenterBase(T view)
        {
            View = view;
        }

        public T View { get; private set; }

        public void CloseView()
        {
            View.CloseView();
        }

        public void ShowNormalView()
        {
            View.ShowNormalView();
        }

        public ModalViewResult ShowModalView()
        {
            return View.ShowModalView();
        }
    }
}
