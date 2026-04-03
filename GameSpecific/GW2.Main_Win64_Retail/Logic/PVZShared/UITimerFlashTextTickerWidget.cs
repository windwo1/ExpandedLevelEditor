using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITimerFlashTextTickerWidgetData))]
	public class UITimerFlashTextTickerWidget : UITickerWidget, IEntityData<FrostySdk.Ebx.UITimerFlashTextTickerWidgetData>
	{
		public new FrostySdk.Ebx.UITimerFlashTextTickerWidgetData Data => data as FrostySdk.Ebx.UITimerFlashTextTickerWidgetData;
		public override string DisplayName => "UITimerFlashTextTickerWidget";

		public UITimerFlashTextTickerWidget(FrostySdk.Ebx.UITimerFlashTextTickerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

