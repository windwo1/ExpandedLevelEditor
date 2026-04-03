using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIWaveManagerEntityData))]
	public class AIWaveManagerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIWaveManagerEntityData>
	{
		public new FrostySdk.Ebx.AIWaveManagerEntityData Data => data as FrostySdk.Ebx.AIWaveManagerEntityData;
		public override string DisplayName => "AIWaveManager";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public AIWaveManagerEntity(FrostySdk.Ebx.AIWaveManagerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

