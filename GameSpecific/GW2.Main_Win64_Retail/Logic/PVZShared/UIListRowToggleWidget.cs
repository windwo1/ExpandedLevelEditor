using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIListRowToggleWidgetData))]
	public class UIListRowToggleWidget : UIListRow, IEntityData<FrostySdk.Ebx.UIListRowToggleWidgetData>
	{
		public new FrostySdk.Ebx.UIListRowToggleWidgetData Data => data as FrostySdk.Ebx.UIListRowToggleWidgetData;
		public override string DisplayName => "UIListRowToggleWidget";

		public UIListRowToggleWidget(FrostySdk.Ebx.UIListRowToggleWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

