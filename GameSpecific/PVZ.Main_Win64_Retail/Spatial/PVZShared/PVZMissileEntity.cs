using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZMissileEntityData))]
	public class PVZMissileEntity : MissileEntity, IEntityData<FrostySdk.Ebx.PVZMissileEntityData>
	{
		public new FrostySdk.Ebx.PVZMissileEntityData Data => data as FrostySdk.Ebx.PVZMissileEntityData;

		public PVZMissileEntity(FrostySdk.Ebx.PVZMissileEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

