using System;
using System.Collections.Generic;
using SC2.Entities;

namespace SC2.Win.Presentation.View
{
    public interface IBuildListView : IView
    {
        IEnumerable<BuildOrderEntity> BuildOrderList { set; }

        event EventHandler<EventArgs> NewBuild;

        event EventHandler<BuildOrderEntity> SelectBuild;

        event EventHandler<EventArgs> SortBuildList;

        event EventHandler<EventArgs> SearchBuild;
    }
}
