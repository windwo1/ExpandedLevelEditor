using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSoldierWeaponData))]
	public class PVZSoldierWeapon : SoldierWeapon, IEntityData<FrostySdk.Ebx.PVZSoldierWeaponData>
	{
		public new FrostySdk.Ebx.PVZSoldierWeaponData Data => data as FrostySdk.Ebx.PVZSoldierWeaponData;

		public PVZSoldierWeapon(FrostySdk.Ebx.PVZSoldierWeaponData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

