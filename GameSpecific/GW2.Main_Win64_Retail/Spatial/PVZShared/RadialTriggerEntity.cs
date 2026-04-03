using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RadialTriggerEntityData))]
	public class RadialTriggerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.RadialTriggerEntityData>
	{
		public new FrostySdk.Ebx.RadialTriggerEntityData Data => data as FrostySdk.Ebx.RadialTriggerEntityData;

		public RadialTriggerEntity(FrostySdk.Ebx.RadialTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

