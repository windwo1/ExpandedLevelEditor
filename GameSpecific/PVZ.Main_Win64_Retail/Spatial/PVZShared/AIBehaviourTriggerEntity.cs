using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIBehaviourTriggerEntityData))]
	public class AIBehaviourTriggerEntity : AreaTriggerEntity, IEntityData<FrostySdk.Ebx.AIBehaviourTriggerEntityData>
	{
		public new FrostySdk.Ebx.AIBehaviourTriggerEntityData Data => data as FrostySdk.Ebx.AIBehaviourTriggerEntityData;

		public AIBehaviourTriggerEntity(FrostySdk.Ebx.AIBehaviourTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

