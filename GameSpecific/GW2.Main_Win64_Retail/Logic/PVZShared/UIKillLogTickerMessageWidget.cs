using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKillLogTickerMessageWidgetData))]
	public class UIKillLogTickerMessageWidget : UITickerMessageWidget, IEntityData<FrostySdk.Ebx.UIKillLogTickerMessageWidgetData>
	{
		public new FrostySdk.Ebx.UIKillLogTickerMessageWidgetData Data => data as FrostySdk.Ebx.UIKillLogTickerMessageWidgetData;
		public override string DisplayName => "UIKillLogTickerMessageWidget";

		public UIKillLogTickerMessageWidget(FrostySdk.Ebx.UIKillLogTickerMessageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

