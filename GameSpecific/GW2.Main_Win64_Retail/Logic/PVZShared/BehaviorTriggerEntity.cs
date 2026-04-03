using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BehaviorTriggerEntityData))]
	public class BehaviorTriggerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BehaviorTriggerEntityData>
	{
		public new FrostySdk.Ebx.BehaviorTriggerEntityData Data => data as FrostySdk.Ebx.BehaviorTriggerEntityData;
		public override string DisplayName => "BehaviorTrigger";

		public BehaviorTriggerEntity(FrostySdk.Ebx.BehaviorTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

