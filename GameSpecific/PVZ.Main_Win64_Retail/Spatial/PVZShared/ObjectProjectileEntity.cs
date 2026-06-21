using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ObjectProjectileEntityData))]
	public class ObjectProjectileEntity : GhostedProjectileEntity, IEntityData<FrostySdk.Ebx.ObjectProjectileEntityData>
	{
		public new FrostySdk.Ebx.ObjectProjectileEntityData Data => data as FrostySdk.Ebx.ObjectProjectileEntityData;

		public ObjectProjectileEntity(FrostySdk.Ebx.ObjectProjectileEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

