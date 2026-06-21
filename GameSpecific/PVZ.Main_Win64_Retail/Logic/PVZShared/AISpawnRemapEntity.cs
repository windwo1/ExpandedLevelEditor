using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AISpawnRemapEntityData))]
	public class AISpawnRemapEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AISpawnRemapEntityData>
	{
		public new FrostySdk.Ebx.AISpawnRemapEntityData Data => data as FrostySdk.Ebx.AISpawnRemapEntityData;
		public override string DisplayName => "AISpawnRemap";

		public AISpawnRemapEntity(FrostySdk.Ebx.AISpawnRemapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

