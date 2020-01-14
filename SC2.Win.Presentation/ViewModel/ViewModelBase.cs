namespace SC2.Win.Presentation.ViewModel
{
    public class ViewModelBase<T> : IViewModel
    {
        public ViewModelBase(T model)
        {
            this.Model = model;
        }

        public T Model { get; private set; }
    }
}
