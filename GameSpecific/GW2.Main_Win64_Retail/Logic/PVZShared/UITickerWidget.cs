using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITickerWidgetData))]
	public class UITickerWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITickerWidgetData>
	{
		public new FrostySdk.Ebx.UITickerWidgetData Data => data as FrostySdk.Ebx.UITickerWidgetData;
		public override string DisplayName => "UITickerWidget";

		public UITickerWidget(FrostySdk.Ebx.UITickerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

