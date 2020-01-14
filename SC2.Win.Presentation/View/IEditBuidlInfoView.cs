using System;
using SC2.Entities;

namespace SC2.Win.Presentation.View
{
    public interface IEditBuildInfoView : IView
    {
        BuildOrderEntity BuildOrderEntity { get; set; }

        event EventHandler SaveBuildOrder;
        event EventHandler BackRequested;
    }
}
