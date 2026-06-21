using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIManageServerRootWidgetData))]
	public class UIManageServerRootWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIManageServerRootWidgetData>
	{
		public new FrostySdk.Ebx.UIManageServerRootWidgetData Data => data as FrostySdk.Ebx.UIManageServerRootWidgetData;
		public override string DisplayName => "UIManageServerRootWidget";

		public UIManageServerRootWidget(FrostySdk.Ebx.UIManageServerRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

