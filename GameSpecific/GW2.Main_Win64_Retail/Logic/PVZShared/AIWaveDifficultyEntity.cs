using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIWaveDifficultyEntityData))]
	public class AIWaveDifficultyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIWaveDifficultyEntityData>
	{
		public new FrostySdk.Ebx.AIWaveDifficultyEntityData Data => data as FrostySdk.Ebx.AIWaveDifficultyEntityData;
		public override string DisplayName => "AIWaveDifficulty";

		public AIWaveDifficultyEntity(FrostySdk.Ebx.AIWaveDifficultyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

