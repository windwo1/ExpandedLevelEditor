using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ScoreInfoEntityData))]
	public class ScoreInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ScoreInfoEntityData>
	{
		public new FrostySdk.Ebx.ScoreInfoEntityData Data => data as FrostySdk.Ebx.ScoreInfoEntityData;
		public override string DisplayName => "ScoreInfo";

		public ScoreInfoEntity(FrostySdk.Ebx.ScoreInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

