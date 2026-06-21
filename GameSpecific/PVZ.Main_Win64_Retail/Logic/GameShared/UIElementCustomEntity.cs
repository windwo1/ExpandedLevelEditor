using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementCustomEntityData))]
	public class UIElementCustomEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementCustomEntityData>
	{
		public new FrostySdk.Ebx.UIElementCustomEntityData Data => data as FrostySdk.Ebx.UIElementCustomEntityData;
		public override string DisplayName => "UIElementCustom";

		public UIElementCustomEntity(FrostySdk.Ebx.UIElementCustomEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

