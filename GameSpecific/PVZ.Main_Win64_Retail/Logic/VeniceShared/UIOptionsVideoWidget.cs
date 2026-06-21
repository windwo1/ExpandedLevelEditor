using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIOptionsVideoWidgetData))]
	public class UIOptionsVideoWidget : UIOptionsListWidget, IEntityData<FrostySdk.Ebx.UIOptionsVideoWidgetData>
	{
		public new FrostySdk.Ebx.UIOptionsVideoWidgetData Data => data as FrostySdk.Ebx.UIOptionsVideoWidgetData;
		public override string DisplayName => "UIOptionsVideoWidget";

		public UIOptionsVideoWidget(FrostySdk.Ebx.UIOptionsVideoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

