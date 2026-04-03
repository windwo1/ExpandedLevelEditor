using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITickerMessageWidgetData))]
	public class UITickerMessageWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITickerMessageWidgetData>
	{
		public new FrostySdk.Ebx.UITickerMessageWidgetData Data => data as FrostySdk.Ebx.UITickerMessageWidgetData;
		public override string DisplayName => "UITickerMessageWidget";

		public UITickerMessageWidget(FrostySdk.Ebx.UITickerMessageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

