using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIControlEntityData))]
	public class AIControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIControlEntityData>
	{
		public new FrostySdk.Ebx.AIControlEntityData Data => data as FrostySdk.Ebx.AIControlEntityData;
		public override string DisplayName => "AIControl";

		public AIControlEntity(FrostySdk.Ebx.AIControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

