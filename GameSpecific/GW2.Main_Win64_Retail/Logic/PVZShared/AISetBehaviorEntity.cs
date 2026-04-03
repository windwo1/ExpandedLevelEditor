using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AISetBehaviorEntityData))]
	public class AISetBehaviorEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AISetBehaviorEntityData>
	{
		public new FrostySdk.Ebx.AISetBehaviorEntityData Data => data as FrostySdk.Ebx.AISetBehaviorEntityData;
		public override string DisplayName => "AISetBehavior";

		public AISetBehaviorEntity(FrostySdk.Ebx.AISetBehaviorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

