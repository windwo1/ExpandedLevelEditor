using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SoldierProjectileEntityData))]
	public class SoldierProjectileEntity : GhostedProjectileEntity, IEntityData<FrostySdk.Ebx.SoldierProjectileEntityData>
	{
		public new FrostySdk.Ebx.SoldierProjectileEntityData Data => data as FrostySdk.Ebx.SoldierProjectileEntityData;

		public SoldierProjectileEntity(FrostySdk.Ebx.SoldierProjectileEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

