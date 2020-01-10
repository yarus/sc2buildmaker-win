using System;
using SC2.Win.Presentation;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public class WinFormViewFactory : IViewFactory
    {
        public T CreateView<T>() where T : class, IView
        {
            if (typeof(T) == typeof(IBuildListView))
            {
                return new BuildList() as T;
            }

            if (typeof(T) == typeof(IBuildMakerView))
            {
                return new BuildMaker() as T;
            }

            if (typeof(T) == typeof(IAddBuildItemListView))
            {
                return new AddBuildItemList() as T;
            }

            if (typeof(T) == typeof(INewBuildView))
            {
                return new NewBuildForm() as T;
            }

            if (typeof(T) == typeof(IEditBuildInfoView))
            {
                return new EditBuildInfoForm() as T;
            }

            throw new ApplicationException(string.Format("View {0} is unsupported", typeof(T)));
        }
    }
}
