using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZDifficultyInfoEntityData))]
	public class PVZDifficultyInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZDifficultyInfoEntityData>
	{
		public new FrostySdk.Ebx.PVZDifficultyInfoEntityData Data => data as FrostySdk.Ebx.PVZDifficultyInfoEntityData;
		public override string DisplayName => "PVZDifficultyInfo";

		public PVZDifficultyInfoEntity(FrostySdk.Ebx.PVZDifficultyInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

