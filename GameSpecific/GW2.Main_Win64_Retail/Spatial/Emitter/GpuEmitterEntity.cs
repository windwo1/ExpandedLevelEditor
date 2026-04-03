using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GpuEmitterEntityData))]
	public class GpuEmitterEntity : ChildEffectEntity, IEntityData<FrostySdk.Ebx.GpuEmitterEntityData>
	{
		public new FrostySdk.Ebx.GpuEmitterEntityData Data => data as FrostySdk.Ebx.GpuEmitterEntityData;

		public GpuEmitterEntity(FrostySdk.Ebx.GpuEmitterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

