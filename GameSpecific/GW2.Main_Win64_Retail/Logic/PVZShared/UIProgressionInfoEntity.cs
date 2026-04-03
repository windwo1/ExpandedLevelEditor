using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIProgressionInfoEntityData))]
	public class UIProgressionInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIProgressionInfoEntityData>
	{
		public new FrostySdk.Ebx.UIProgressionInfoEntityData Data => data as FrostySdk.Ebx.UIProgressionInfoEntityData;
		public override string DisplayName => "UIProgressionInfo";

		public UIProgressionInfoEntity(FrostySdk.Ebx.UIProgressionInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

