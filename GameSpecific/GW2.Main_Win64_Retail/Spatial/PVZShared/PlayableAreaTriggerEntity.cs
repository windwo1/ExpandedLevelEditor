using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlayableAreaTriggerEntityData))]
	public class PlayableAreaTriggerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.PlayableAreaTriggerEntityData>
	{
		public new FrostySdk.Ebx.PlayableAreaTriggerEntityData Data => data as FrostySdk.Ebx.PlayableAreaTriggerEntityData;

		public PlayableAreaTriggerEntity(FrostySdk.Ebx.PlayableAreaTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

