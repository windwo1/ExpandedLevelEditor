using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKillLogTickerWidgetData))]
	public class UIKillLogTickerWidget : UITickerWidget, IEntityData<FrostySdk.Ebx.UIKillLogTickerWidgetData>
	{
		public new FrostySdk.Ebx.UIKillLogTickerWidgetData Data => data as FrostySdk.Ebx.UIKillLogTickerWidgetData;
		public override string DisplayName => "UIKillLogTickerWidget";

		public UIKillLogTickerWidget(FrostySdk.Ebx.UIKillLogTickerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

