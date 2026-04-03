using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIAreaTriggerEntityData))]
	public class AIAreaTriggerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIAreaTriggerEntityData>
	{
		public new FrostySdk.Ebx.AIAreaTriggerEntityData Data => data as FrostySdk.Ebx.AIAreaTriggerEntityData;
		public override string DisplayName => "AIAreaTrigger";

		public AIAreaTriggerEntity(FrostySdk.Ebx.AIAreaTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

