using System;
using SC2.DataManagers;
using SC2.Entities;
using SC2.Win.Presentation.View;

namespace SC2.Win.Presentation.Presenter
{
    public class NewBuildPresenter : PresenterBase<INewBuildView>
    {
        private readonly ISC2VersionsManager mVersionsManager;

        public NewBuildPresenter(INewBuildView view, ISC2VersionsManager versionsManager)
            : base(view)
        {
            mVersionsManager = versionsManager;

            view.BackRequested += ViewBackRequested;
            view.SelectionDone += ViewSelectionDone;

            view.VersionIDs = mVersionsManager.GetSupportedVersionIDs();
        }

        void ViewSelectionDone(object sender, RaceEnum e)
        {
            if (CreateNewBuildRequested != null)
            {
                var versionInfo = mVersionsManager.GetVersion(View.SelectedVersion);

                CreateNewBuildRequested(this, new BuildOrderEntity { Race = e, SC2VersionID = View.SelectedVersion, AddonID = versionInfo.AddonID });
            }
        }

        void ViewBackRequested(object sender, EventArgs e)
        {
            if (BackRequested != null)
            {
                BackRequested(this, new EventArgs());
            }
        }

        public event EventHandler BackRequested;

        public event EventHandler<BuildOrderEntity> CreateNewBuildRequested;
    }
}
