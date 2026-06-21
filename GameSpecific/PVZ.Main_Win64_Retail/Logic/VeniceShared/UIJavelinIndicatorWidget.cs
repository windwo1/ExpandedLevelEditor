using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIJavelinIndicatorWidgetData))]
	public class UIJavelinIndicatorWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIJavelinIndicatorWidgetData>
	{
		public new FrostySdk.Ebx.UIJavelinIndicatorWidgetData Data => data as FrostySdk.Ebx.UIJavelinIndicatorWidgetData;
		public override string DisplayName => "UIJavelinIndicatorWidget";

		public UIJavelinIndicatorWidget(FrostySdk.Ebx.UIJavelinIndicatorWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

