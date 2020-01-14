using System;
using System.Collections.Generic;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.Presentation.View
{
    public interface IAddBuildItemListView : IView
    {
        IEnumerable<BuildItemAddButtonViewModel> BuildItems { set; }

        event EventHandler<string> ItemSelected;
        event EventHandler Cancel;
    }
}
