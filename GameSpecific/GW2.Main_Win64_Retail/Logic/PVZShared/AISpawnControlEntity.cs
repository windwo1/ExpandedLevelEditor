using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AISpawnControlEntityData))]
	public class AISpawnControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AISpawnControlEntityData>
	{
		public new FrostySdk.Ebx.AISpawnControlEntityData Data => data as FrostySdk.Ebx.AISpawnControlEntityData;
		public override string DisplayName => "AISpawnControl";

		public AISpawnControlEntity(FrostySdk.Ebx.AISpawnControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

