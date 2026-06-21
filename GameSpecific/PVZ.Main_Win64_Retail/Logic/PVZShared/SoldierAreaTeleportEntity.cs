using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SoldierAreaTeleportEntityData))]
	public class SoldierAreaTeleportEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SoldierAreaTeleportEntityData>
	{
		public new FrostySdk.Ebx.SoldierAreaTeleportEntityData Data => data as FrostySdk.Ebx.SoldierAreaTeleportEntityData;
		public override string DisplayName => "SoldierAreaTeleport";

		public SoldierAreaTeleportEntity(FrostySdk.Ebx.SoldierAreaTeleportEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

