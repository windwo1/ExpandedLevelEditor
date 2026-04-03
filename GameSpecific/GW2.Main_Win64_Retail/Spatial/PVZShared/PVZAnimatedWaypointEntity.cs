using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAnimatedWaypointEntityData))]
	public class PVZAnimatedWaypointEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.PVZAnimatedWaypointEntityData>
	{
		public new FrostySdk.Ebx.PVZAnimatedWaypointEntityData Data => data as FrostySdk.Ebx.PVZAnimatedWaypointEntityData;
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAnimatedWaypointEntity(FrostySdk.Ebx.PVZAnimatedWaypointEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

