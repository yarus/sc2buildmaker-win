using SC2.PublicData;

namespace SC2.Entities.BuildItems
{
    public interface IBuildItemRequirement
    {
        string RequirementName { get; }

        ItemWithAttributesInfo GetAttributesInfo();
        
        bool IsRequirementSatisfied(BuildItemStatistics stats);
    }
}
