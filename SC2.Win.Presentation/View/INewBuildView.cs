using System;
using System.Collections.Generic;
using SC2.Entities;

namespace SC2.Win.Presentation.View
{
    public interface INewBuildView : IView
    {
        IEnumerable<string> VersionIDs { set; }

        string SelectedVersion { get; }

        event EventHandler BackRequested;

        event EventHandler<RaceEnum> SelectionDone;
    }
}
