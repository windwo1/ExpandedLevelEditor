using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITimerFlashTextTickerMessageWidgetData))]
	public class UITimerFlashTextTickerMessageWidget : UITickerMessageWidget, IEntityData<FrostySdk.Ebx.UITimerFlashTextTickerMessageWidgetData>
	{
		public new FrostySdk.Ebx.UITimerFlashTextTickerMessageWidgetData Data => data as FrostySdk.Ebx.UITimerFlashTextTickerMessageWidgetData;
		public override string DisplayName => "UITimerFlashTextTickerMessageWidget";

		public UITimerFlashTextTickerMessageWidget(FrostySdk.Ebx.UITimerFlashTextTickerMessageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

