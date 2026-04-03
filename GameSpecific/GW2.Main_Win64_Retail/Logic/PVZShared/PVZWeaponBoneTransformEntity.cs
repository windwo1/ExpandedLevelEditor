using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZWeaponBoneTransformEntityData))]
	public class PVZWeaponBoneTransformEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZWeaponBoneTransformEntityData>
	{
		public new FrostySdk.Ebx.PVZWeaponBoneTransformEntityData Data => data as FrostySdk.Ebx.PVZWeaponBoneTransformEntityData;
		public override string DisplayName => "PVZWeaponBoneTransform";

		public PVZWeaponBoneTransformEntity(FrostySdk.Ebx.PVZWeaponBoneTransformEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

