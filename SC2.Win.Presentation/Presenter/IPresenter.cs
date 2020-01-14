namespace SC2.Win.Presentation.Presenter
{
    public interface IPresenter
    {
        void CloseView();

        void ShowNormalView();

        ModalViewResult ShowModalView();
    }
}
