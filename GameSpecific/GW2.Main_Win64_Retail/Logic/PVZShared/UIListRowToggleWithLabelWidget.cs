using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIListRowToggleWithLabelWidgetData))]
	public class UIListRowToggleWithLabelWidget : UIListRowToggleWidget, IEntityData<FrostySdk.Ebx.UIListRowToggleWithLabelWidgetData>
	{
		public new FrostySdk.Ebx.UIListRowToggleWithLabelWidgetData Data => data as FrostySdk.Ebx.UIListRowToggleWithLabelWidgetData;
		public override string DisplayName => "UIListRowToggleWithLabelWidget";

		public UIListRowToggleWithLabelWidget(FrostySdk.Ebx.UIListRowToggleWithLabelWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

