using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SpatialWeaponEntityData))]
	public class SpatialWeaponEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.SpatialWeaponEntityData>
	{
		public new FrostySdk.Ebx.SpatialWeaponEntityData Data => data as FrostySdk.Ebx.SpatialWeaponEntityData;

		public SpatialWeaponEntity(FrostySdk.Ebx.SpatialWeaponEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

