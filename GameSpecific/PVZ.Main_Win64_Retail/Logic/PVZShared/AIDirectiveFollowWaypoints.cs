using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIDirectiveFollowWaypointsData))]
	public class AIDirectiveFollowWaypoints : AIDirective, IEntityData<FrostySdk.Ebx.AIDirectiveFollowWaypointsData>
	{
		public new FrostySdk.Ebx.AIDirectiveFollowWaypointsData Data => data as FrostySdk.Ebx.AIDirectiveFollowWaypointsData;
		public override string DisplayName => "AIDirectiveFollowWaypoints";

		public AIDirectiveFollowWaypoints(FrostySdk.Ebx.AIDirectiveFollowWaypointsData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

