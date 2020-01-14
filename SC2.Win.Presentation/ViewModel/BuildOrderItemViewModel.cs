using System.Drawing;
using SC2.Entities.BuildItems;
using SC2.Entities.BuildOrderProcessor;

namespace SC2.Win.Presentation.ViewModel
{
    public class BuildOrderItemViewModel : ViewModelBase<BuildOrderProcessorItem>
    {
        private readonly BuildItemEntity mBuildItem;
        
        public BuildOrderItemViewModel(BuildOrderProcessorItem model, BuildItemEntity buildItem)
            : base(model)
        {
            this.mBuildItem = buildItem;
        }

        public string ItemName 
        { 
            get
            {
                return mBuildItem.DisplayName;
            }
        }

        public string BuildTime 
        { 
            get
            {
                return CalculateTimeView(Model.SecondInTimeLine, Model.FinishedSecond);
            }
        }

        public Color ItemColor 
        { 
            get
            {
                return GetRowColorFromItemType(mBuildItem.ItemType);
            }
        }

        public int Minerals
        {
            get
            {
                return Model.StatisticsProvider.Minerals;
            }
        }

        public int Gas
        {
            get
            {
                return Model.StatisticsProvider.Gas;
            }
        }

        public string Supply 
        { 
            get
            {
                return CalculateSupplyView(Model.StatisticsProvider.CurrentSupply, Model.StatisticsProvider.MaximumSupply);
            }
        }

        #region Common converting methods

        private static Color GetRowColorFromItemType(BuildItemTypeEnum itemType)
        {
            switch (itemType)
            {
                case BuildItemTypeEnum.Unit: return Color.LightGreen;
                case BuildItemTypeEnum.Building: return Color.DarkOrange;
                case BuildItemTypeEnum.Special: return Color.Bisque;
                case BuildItemTypeEnum.Upgrade: return Color.LightBlue;
                default: return Color.White;
            }
        }

        private static string CalculateSupplyView(int current, int maximum)
        {
            return string.Format("{0}/{1}", current, maximum);
        }

        private static string CalculateTimeView(int startedSecond, int finishedSecond)
        {
            var started = CalculateTimeFromSeconds(startedSecond);
            var finished = CalculateTimeFromSeconds(finishedSecond);

            return string.Format("{0}-{1}", started, finished);
        }

        private static string CalculatePartTimeView(int second)
        {
            if (second < 10)
            {
                return string.Format("0{0}", second);
            }

            if (second < 60)
            {
                return string.Format("{0}", second);
            }

            return "--";
        }

        private static string CalculateTimeFromSeconds(int second)
        {
            int min = second / 60;
            string strMin = CalculatePartTimeView(min);
            string strSec = CalculatePartTimeView(second - min * 60);

            return string.Format("{0}:{1}", strMin, strSec);
        }

        #endregion
    }
}
