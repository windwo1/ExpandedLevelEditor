using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZLaserSoldierWeaponData))]
	public class PVZLaserSoldierWeapon : PVZSoldierWeapon, IEntityData<FrostySdk.Ebx.PVZLaserSoldierWeaponData>
	{
		public new FrostySdk.Ebx.PVZLaserSoldierWeaponData Data => data as FrostySdk.Ebx.PVZLaserSoldierWeaponData;

		public PVZLaserSoldierWeapon(FrostySdk.Ebx.PVZLaserSoldierWeaponData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

