using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITwoLinerWidgetData))]
	public class UITwoLinerWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITwoLinerWidgetData>
	{
		public new FrostySdk.Ebx.UITwoLinerWidgetData Data => data as FrostySdk.Ebx.UITwoLinerWidgetData;
		public override string DisplayName => "UITwoLinerWidget";

		public UITwoLinerWidget(FrostySdk.Ebx.UITwoLinerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

