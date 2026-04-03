using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LevelConfigEntityData))]
	public class LevelConfigEntity : LogicEntity, IEntityData<FrostySdk.Ebx.LevelConfigEntityData>
	{
		public new FrostySdk.Ebx.LevelConfigEntityData Data => data as FrostySdk.Ebx.LevelConfigEntityData;
		public override string DisplayName => "LevelConfig";

		public LevelConfigEntity(FrostySdk.Ebx.LevelConfigEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

