using SC2.Win.Presentation.View;

namespace SC2.Win.Presentation
{
    public interface IViewFactory
    {
        T CreateView<T>() where T : class, IView;
    }
}