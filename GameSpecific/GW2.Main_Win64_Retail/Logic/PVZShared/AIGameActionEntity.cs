using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIGameActionEntityData))]
	public class AIGameActionEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIGameActionEntityData>
	{
		public new FrostySdk.Ebx.AIGameActionEntityData Data => data as FrostySdk.Ebx.AIGameActionEntityData;
		public override string DisplayName => "AIGameAction";

		public AIGameActionEntity(FrostySdk.Ebx.AIGameActionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

