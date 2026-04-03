using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAnimatedWaypointFollowerEntityData))]
	public class PVZAnimatedWaypointFollowerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAnimatedWaypointFollowerEntityData>
	{
		public new FrostySdk.Ebx.PVZAnimatedWaypointFollowerEntityData Data => data as FrostySdk.Ebx.PVZAnimatedWaypointFollowerEntityData;
		public override string DisplayName => "PVZAnimatedWaypointFollower";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAnimatedWaypointFollowerEntity(FrostySdk.Ebx.PVZAnimatedWaypointFollowerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

