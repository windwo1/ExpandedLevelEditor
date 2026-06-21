using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSoldierEntityData))]
	public class PVZSoldierEntity : SoldierEntity, IEntityData<FrostySdk.Ebx.PVZSoldierEntityData>
	{
		public new FrostySdk.Ebx.PVZSoldierEntityData Data => data as FrostySdk.Ebx.PVZSoldierEntityData;

		public PVZSoldierEntity(FrostySdk.Ebx.PVZSoldierEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

