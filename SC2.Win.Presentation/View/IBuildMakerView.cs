using System;
using SC2.Entities.BuildItems;
using SC2.Win.Presentation.ViewModel;

namespace SC2.Win.Presentation.View
{
    public interface IBuildMakerView : IView
    {
        BuildMakerViewModel ViewModel { set; }

        event EventHandler SaveBuild;
        event EventHandler UndoItem;
        event EventHandler ClearBuild;
        event EventHandler BackRequested;

        event EventHandler<BuildItemTypeEnum> AddItemRequested;
    }
}
