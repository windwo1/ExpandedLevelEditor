using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RewardDestructibleSpawnEntityData))]
	public class RewardDestructibleSpawnEntity : LogicEntity, IEntityData<FrostySdk.Ebx.RewardDestructibleSpawnEntityData>
	{
		public new FrostySdk.Ebx.RewardDestructibleSpawnEntityData Data => data as FrostySdk.Ebx.RewardDestructibleSpawnEntityData;
		public override string DisplayName => "RewardDestructibleSpawn";

		public RewardDestructibleSpawnEntity(FrostySdk.Ebx.RewardDestructibleSpawnEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

