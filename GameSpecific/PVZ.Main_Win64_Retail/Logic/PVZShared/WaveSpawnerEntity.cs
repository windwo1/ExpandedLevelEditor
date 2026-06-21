using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WaveSpawnerEntityData))]
	public class WaveSpawnerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.WaveSpawnerEntityData>
	{
		public new FrostySdk.Ebx.WaveSpawnerEntityData Data => data as FrostySdk.Ebx.WaveSpawnerEntityData;
		public override string DisplayName => "WaveSpawner";

		public WaveSpawnerEntity(FrostySdk.Ebx.WaveSpawnerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

