using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIDestructibleSpawnEntityData))]
	public class AIDestructibleSpawnEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIDestructibleSpawnEntityData>
	{
		public new FrostySdk.Ebx.AIDestructibleSpawnEntityData Data => data as FrostySdk.Ebx.AIDestructibleSpawnEntityData;
		public override string DisplayName => "AIDestructibleSpawn";

		public AIDestructibleSpawnEntity(FrostySdk.Ebx.AIDestructibleSpawnEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

