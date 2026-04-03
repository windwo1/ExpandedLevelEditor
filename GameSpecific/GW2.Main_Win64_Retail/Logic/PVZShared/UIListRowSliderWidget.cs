using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIListRowSliderWidgetData))]
	public class UIListRowSliderWidget : UIListRowLabelWidget, IEntityData<FrostySdk.Ebx.UIListRowSliderWidgetData>
	{
		public new FrostySdk.Ebx.UIListRowSliderWidgetData Data => data as FrostySdk.Ebx.UIListRowSliderWidgetData;
		public override string DisplayName => "UIListRowSliderWidget";

		public UIListRowSliderWidget(FrostySdk.Ebx.UIListRowSliderWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

