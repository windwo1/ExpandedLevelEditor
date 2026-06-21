using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DynamicEnvmapEntityData))]
	public class DynamicEnvmapEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.DynamicEnvmapEntityData>
	{
		public new FrostySdk.Ebx.DynamicEnvmapEntityData Data => data as FrostySdk.Ebx.DynamicEnvmapEntityData;

		public DynamicEnvmapEntity(FrostySdk.Ebx.DynamicEnvmapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

