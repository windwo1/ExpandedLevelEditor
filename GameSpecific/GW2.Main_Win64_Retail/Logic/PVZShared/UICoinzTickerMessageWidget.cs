using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICoinzTickerMessageWidgetData))]
	public class UICoinzTickerMessageWidget : UITickerMessageWidget, IEntityData<FrostySdk.Ebx.UICoinzTickerMessageWidgetData>
	{
		public new FrostySdk.Ebx.UICoinzTickerMessageWidgetData Data => data as FrostySdk.Ebx.UICoinzTickerMessageWidgetData;
		public override string DisplayName => "UICoinzTickerMessageWidget";

		public UICoinzTickerMessageWidget(FrostySdk.Ebx.UICoinzTickerMessageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

