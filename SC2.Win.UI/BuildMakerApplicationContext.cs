using System.Linq;
using System.Windows.Forms;
using SC2.DataManagers.Configurators;
using SC2.UnitTests.TestData;
using SC2.Win.Presentation;
using SC2.Win.Presentation.View;

namespace SC2.Win.UI
{
    public class BuildMakerApplicationContext : ApplicationContext
    {
        private readonly UIWorkflow mUiWorkflow;

        public BuildMakerApplicationContext()
        {
            // Note: To run test workflow uncomment next line and comment CreateUiWorkflow() merthod call
            mUiWorkflow = CreateTestUiWorkflow();
            //mUiWorkflow = CreateUiWorkflow();

            mUiWorkflow.CurrentViewChanged += MUiWorkflowCurrentViewChanged;
            mUiWorkflow.ShowMainForm();
        }

        void MUiWorkflowCurrentViewChanged(object sender, IView e)
        {
            MainForm = e as FormBase;
        }

        private UIWorkflow CreateUiWorkflow()
        {
            var workflow = new UIWorkflow(new DataManagersJsonStorageConfigurator("Versions//"), new WinFormViewFactory());

            return workflow;
        }

        private UIWorkflow CreateTestUiWorkflow()
        {
            var dataManagerConfigurator = new TestDataManagersConfigurator();

            // Generate Test version file
            var versionsManager = dataManagerConfigurator.GetSC2VersionsManager();

            //var version2 = versionsManager.GetVersion("2.0.5", "WOL");
            //versionsManager.SaveVersion(version2);

            //var version = versionsManager.GetVersion("2.2.0", "HOTS");
            //versionsManager.SaveVersion(version);

            var version3 = versionsManager.GetVersion("5.0.3");
            versionsManager.SaveVersion(version3);

            // Generate test builds files
            //var boManagers = dataManagerConfigurator.GetBuildOrdersManager();
//            var testBuilds = boManagers.GetBuildOrders().ToList();
//            foreach (var buildOrderEntity in testBuilds)
//            {
//                boManagers.SaveBuildOrder(buildOrderEntity);
//            }

            var workflow = new UIWorkflow(dataManagerConfigurator, new WinFormViewFactory());

            return workflow;
        }

    }
}
