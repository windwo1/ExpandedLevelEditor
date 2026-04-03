using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterWeaponData))]
	public class PVZCharacterWeapon : WeaponEntity, IEntityData<FrostySdk.Ebx.PVZCharacterWeaponData>
	{
		public new FrostySdk.Ebx.PVZCharacterWeaponData Data => data as FrostySdk.Ebx.PVZCharacterWeaponData;

		public PVZCharacterWeapon(FrostySdk.Ebx.PVZCharacterWeaponData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

