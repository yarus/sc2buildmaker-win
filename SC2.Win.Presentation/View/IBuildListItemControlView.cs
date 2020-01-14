using System;
using SC2.Entities;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.Presentation.View
{
    public interface IBuildListItemControlView : IView
    {
        BuildOrderListItemViewModel BuildOrder { get; set; }
        event EventHandler<BuildOrderEntity> ItemClicked;
    }
}