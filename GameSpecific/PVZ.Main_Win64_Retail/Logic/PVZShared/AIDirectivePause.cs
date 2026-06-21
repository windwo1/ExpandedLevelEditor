using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIDirectivePauseData))]
	public class AIDirectivePause : AIDirective, IEntityData<FrostySdk.Ebx.AIDirectivePauseData>
	{
		public new FrostySdk.Ebx.AIDirectivePauseData Data => data as FrostySdk.Ebx.AIDirectivePauseData;
		public override string DisplayName => "AIDirectivePause";

		public AIDirectivePause(FrostySdk.Ebx.AIDirectivePauseData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

