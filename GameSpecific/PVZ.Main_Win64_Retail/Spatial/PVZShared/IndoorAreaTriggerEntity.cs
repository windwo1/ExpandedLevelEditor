using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.IndoorAreaTriggerEntityData))]
	public class IndoorAreaTriggerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.IndoorAreaTriggerEntityData>
	{
		public new FrostySdk.Ebx.IndoorAreaTriggerEntityData Data => data as FrostySdk.Ebx.IndoorAreaTriggerEntityData;

		public IndoorAreaTriggerEntity(FrostySdk.Ebx.IndoorAreaTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

