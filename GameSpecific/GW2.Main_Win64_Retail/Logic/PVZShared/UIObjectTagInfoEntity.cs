using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectTagInfoEntityData))]
	public class UIObjectTagInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIObjectTagInfoEntityData>
	{
		public new FrostySdk.Ebx.UIObjectTagInfoEntityData Data => data as FrostySdk.Ebx.UIObjectTagInfoEntityData;
		public override string DisplayName => "UIObjectTagInfo";

		public UIObjectTagInfoEntity(FrostySdk.Ebx.UIObjectTagInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

