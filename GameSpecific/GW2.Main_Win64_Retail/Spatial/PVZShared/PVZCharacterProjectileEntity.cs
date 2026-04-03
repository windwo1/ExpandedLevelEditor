using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterProjectileEntityData))]
	public class PVZCharacterProjectileEntity : GhostedProjectileEntity, IEntityData<FrostySdk.Ebx.PVZCharacterProjectileEntityData>
	{
		public new FrostySdk.Ebx.PVZCharacterProjectileEntityData Data => data as FrostySdk.Ebx.PVZCharacterProjectileEntityData;

		public PVZCharacterProjectileEntity(FrostySdk.Ebx.PVZCharacterProjectileEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

