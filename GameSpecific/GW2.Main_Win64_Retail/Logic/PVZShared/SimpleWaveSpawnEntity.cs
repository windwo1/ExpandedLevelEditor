using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SimpleWaveSpawnEntityData))]
	public class SimpleWaveSpawnEntity : BaseWaveSpawnEntity, IEntityData<FrostySdk.Ebx.SimpleWaveSpawnEntityData>
	{
		public new FrostySdk.Ebx.SimpleWaveSpawnEntityData Data => data as FrostySdk.Ebx.SimpleWaveSpawnEntityData;
		public override string DisplayName => "SimpleWaveSpawn";

		public SimpleWaveSpawnEntity(FrostySdk.Ebx.SimpleWaveSpawnEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

