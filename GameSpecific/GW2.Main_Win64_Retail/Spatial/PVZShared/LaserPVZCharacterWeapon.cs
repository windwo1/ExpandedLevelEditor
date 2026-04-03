using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LaserPVZCharacterWeaponData))]
	public class LaserPVZCharacterWeapon : PVZCharacterWeapon, IEntityData<FrostySdk.Ebx.LaserPVZCharacterWeaponData>
	{
		public new FrostySdk.Ebx.LaserPVZCharacterWeaponData Data => data as FrostySdk.Ebx.LaserPVZCharacterWeaponData;

		public LaserPVZCharacterWeapon(FrostySdk.Ebx.LaserPVZCharacterWeaponData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

