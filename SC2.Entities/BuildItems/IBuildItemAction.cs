using SC2.PublicData;

namespace SC2.Entities.BuildItems
{
    public interface IBuildItemAction
    {
        string ActionName { get; }

        void DoAction(BuildItemStatistics statistics);

        ItemWithAttributesInfo GetAttributesInfo();
    }
}