using SC2.PublicData;

namespace SC2.Entities.BuildItems.Requirements
{
    public class OrBuildItemRequirement : IBuildItemRequirement
    {
        public IBuildItemRequirement LeftBuildItemRequirement { get; private set; }
        public IBuildItemRequirement RightBuildItemRequirement { get; private set; }

        public OrBuildItemRequirement(IBuildItemRequirement leftBuildItemRequirement, IBuildItemRequirement alternateBuildItemRequirement)
        {
            this.LeftBuildItemRequirement = leftBuildItemRequirement;
            this.RightBuildItemRequirement = alternateBuildItemRequirement;
        }

        public string RequirementName { get { return BuildItemRequirementFactory.OrBuildItemRequirement; } }

        public ItemWithAttributesInfo GetAttributesInfo()
        {
            var item = new ItemWithAttributesInfo
            {
                Name = this.RequirementName
            };

            item.ChildItems.Add(this.LeftBuildItemRequirement.GetAttributesInfo());
            item.ChildItems.Add(this.RightBuildItemRequirement.GetAttributesInfo());

            return item;
        }

        public bool IsRequirementSatisfied(BuildItemStatistics stats)
        {
            if (this.LeftBuildItemRequirement == null && this.RightBuildItemRequirement != null)
            {
                return this.RightBuildItemRequirement.IsRequirementSatisfied(stats);
            }

            if (this.LeftBuildItemRequirement != null && this.RightBuildItemRequirement == null)
            {
                return this.LeftBuildItemRequirement.IsRequirementSatisfied(stats);
            }

            if (this.LeftBuildItemRequirement != null && this.RightBuildItemRequirement != null)
            {
                return this.LeftBuildItemRequirement.IsRequirementSatisfied(stats) ||
                       this.RightBuildItemRequirement.IsRequirementSatisfied(stats);
            }

            return true;
        }
    }
}
