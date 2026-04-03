using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZFriendZoneEntityData))]
	public class PVZFriendZoneEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZFriendZoneEntityData>
	{
		public new FrostySdk.Ebx.PVZFriendZoneEntityData Data => data as FrostySdk.Ebx.PVZFriendZoneEntityData;
		public override string DisplayName => "PVZFriendZone";

		public PVZFriendZoneEntity(FrostySdk.Ebx.PVZFriendZoneEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

