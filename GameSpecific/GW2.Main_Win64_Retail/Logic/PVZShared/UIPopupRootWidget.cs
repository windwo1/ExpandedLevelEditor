using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPopupRootWidgetData))]
	public class UIPopupRootWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPopupRootWidgetData>
	{
		public new FrostySdk.Ebx.UIPopupRootWidgetData Data => data as FrostySdk.Ebx.UIPopupRootWidgetData;
		public override string DisplayName => "UIPopupRootWidget";

		public UIPopupRootWidget(FrostySdk.Ebx.UIPopupRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

