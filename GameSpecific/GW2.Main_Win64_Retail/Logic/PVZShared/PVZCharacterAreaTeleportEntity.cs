using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterAreaTeleportEntityData))]
	public class PVZCharacterAreaTeleportEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZCharacterAreaTeleportEntityData>
	{
		public new FrostySdk.Ebx.PVZCharacterAreaTeleportEntityData Data => data as FrostySdk.Ebx.PVZCharacterAreaTeleportEntityData;
		public override string DisplayName => "PVZCharacterAreaTeleport";

		public PVZCharacterAreaTeleportEntity(FrostySdk.Ebx.PVZCharacterAreaTeleportEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

