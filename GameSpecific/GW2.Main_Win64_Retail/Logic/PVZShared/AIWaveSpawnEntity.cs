using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIWaveSpawnEntityData))]
	public class AIWaveSpawnEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIWaveSpawnEntityData>
	{
		public new FrostySdk.Ebx.AIWaveSpawnEntityData Data => data as FrostySdk.Ebx.AIWaveSpawnEntityData;
		public override string DisplayName => "AIWaveSpawn";

		public AIWaveSpawnEntity(FrostySdk.Ebx.AIWaveSpawnEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

