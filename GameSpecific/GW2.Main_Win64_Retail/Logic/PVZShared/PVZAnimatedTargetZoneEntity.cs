using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAnimatedTargetZoneEntityData))]
	public class PVZAnimatedTargetZoneEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAnimatedTargetZoneEntityData>
	{
		public new FrostySdk.Ebx.PVZAnimatedTargetZoneEntityData Data => data as FrostySdk.Ebx.PVZAnimatedTargetZoneEntityData;
		public override string DisplayName => "PVZAnimatedTargetZone";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAnimatedTargetZoneEntity(FrostySdk.Ebx.PVZAnimatedTargetZoneEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

