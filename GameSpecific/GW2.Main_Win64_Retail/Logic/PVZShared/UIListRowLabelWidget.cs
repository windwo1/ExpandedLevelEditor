using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIListRowLabelWidgetData))]
	public class UIListRowLabelWidget : UIListRow, IEntityData<FrostySdk.Ebx.UIListRowLabelWidgetData>
	{
		public new FrostySdk.Ebx.UIListRowLabelWidgetData Data => data as FrostySdk.Ebx.UIListRowLabelWidgetData;
		public override string DisplayName => "UIListRowLabelWidget";

		public UIListRowLabelWidget(FrostySdk.Ebx.UIListRowLabelWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

