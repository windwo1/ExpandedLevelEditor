using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIHighlightWidgetData))]
	public class UIHighlightWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIHighlightWidgetData>
	{
		public new FrostySdk.Ebx.UIHighlightWidgetData Data => data as FrostySdk.Ebx.UIHighlightWidgetData;
		public override string DisplayName => "UIHighlightWidget";

		public UIHighlightWidget(FrostySdk.Ebx.UIHighlightWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

