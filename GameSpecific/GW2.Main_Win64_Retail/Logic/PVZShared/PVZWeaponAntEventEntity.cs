using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZWeaponAntEventEntityData))]
	public class PVZWeaponAntEventEntity : AntEventEntity, IEntityData<FrostySdk.Ebx.PVZWeaponAntEventEntityData>
	{
		public new FrostySdk.Ebx.PVZWeaponAntEventEntityData Data => data as FrostySdk.Ebx.PVZWeaponAntEventEntityData;
		public override string DisplayName => "PVZWeaponAntEvent";

		public PVZWeaponAntEventEntity(FrostySdk.Ebx.PVZWeaponAntEventEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

