using System;
using System.Collections.Generic;

namespace SC2.Entities
{
    [Serializable]
	public class BuildOrderEntity
	{
		public string Name { get; set; }
		public string SC2VersionID { get; set; }
		public string Description { get; set; }
		public RaceEnum Race { get; set; }
		public RaceEnum VsRace { get; set; }
		public List<string> BuildOrderItems { get; set; }

		public string AddonID { get; set; }

		public BuildOrderEntity()
		{
			this.BuildOrderItems = new List<string>();
		}
	}
}
