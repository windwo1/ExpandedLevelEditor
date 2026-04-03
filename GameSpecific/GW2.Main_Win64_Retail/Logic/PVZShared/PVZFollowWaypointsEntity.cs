using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZFollowWaypointsEntityData))]
	public class PVZFollowWaypointsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZFollowWaypointsEntityData>
	{
		public new FrostySdk.Ebx.PVZFollowWaypointsEntityData Data => data as FrostySdk.Ebx.PVZFollowWaypointsEntityData;
		public override string DisplayName => "PVZFollowWaypoints";

		public PVZFollowWaypointsEntity(FrostySdk.Ebx.PVZFollowWaypointsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

