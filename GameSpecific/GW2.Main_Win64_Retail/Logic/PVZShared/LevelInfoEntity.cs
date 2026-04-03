using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LevelInfoEntityData))]
	public class LevelInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.LevelInfoEntityData>
	{
		public new FrostySdk.Ebx.LevelInfoEntityData Data => data as FrostySdk.Ebx.LevelInfoEntityData;
		public override string DisplayName => "LevelInfo";

		public LevelInfoEntity(FrostySdk.Ebx.LevelInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

