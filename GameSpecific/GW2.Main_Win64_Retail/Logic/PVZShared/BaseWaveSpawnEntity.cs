using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BaseWaveSpawnEntityData))]
	public class BaseWaveSpawnEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BaseWaveSpawnEntityData>
	{
		public new FrostySdk.Ebx.BaseWaveSpawnEntityData Data => data as FrostySdk.Ebx.BaseWaveSpawnEntityData;
		public override string DisplayName => "BaseWaveSpawn";

		public BaseWaveSpawnEntity(FrostySdk.Ebx.BaseWaveSpawnEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

