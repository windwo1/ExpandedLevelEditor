using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIWaveStateEntityData))]
	public class AIWaveStateEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIWaveStateEntityData>
	{
		public new FrostySdk.Ebx.AIWaveStateEntityData Data => data as FrostySdk.Ebx.AIWaveStateEntityData;
		public override string DisplayName => "AIWaveState";

		public AIWaveStateEntity(FrostySdk.Ebx.AIWaveStateEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

