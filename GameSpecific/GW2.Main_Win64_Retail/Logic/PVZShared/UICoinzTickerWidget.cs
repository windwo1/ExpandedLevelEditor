using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICoinzTickerWidgetData))]
	public class UICoinzTickerWidget : UITickerWidget, IEntityData<FrostySdk.Ebx.UICoinzTickerWidgetData>
	{
		public new FrostySdk.Ebx.UICoinzTickerWidgetData Data => data as FrostySdk.Ebx.UICoinzTickerWidgetData;
		public override string DisplayName => "UICoinzTickerWidget";

		public UICoinzTickerWidget(FrostySdk.Ebx.UICoinzTickerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

