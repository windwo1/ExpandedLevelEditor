using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CoopWaveSpawnEntityData))]
	public class CoopWaveSpawnEntity : BaseWaveSpawnEntity, IEntityData<FrostySdk.Ebx.CoopWaveSpawnEntityData>
	{
		public new FrostySdk.Ebx.CoopWaveSpawnEntityData Data => data as FrostySdk.Ebx.CoopWaveSpawnEntityData;
		public override string DisplayName => "CoopWaveSpawn";

		public CoopWaveSpawnEntity(FrostySdk.Ebx.CoopWaveSpawnEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

