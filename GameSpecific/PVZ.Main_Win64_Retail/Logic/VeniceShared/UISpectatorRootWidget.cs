using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorRootWidgetData))]
	public class UISpectatorRootWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorRootWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorRootWidgetData Data => data as FrostySdk.Ebx.UISpectatorRootWidgetData;
		public override string DisplayName => "UISpectatorRootWidget";

		public UISpectatorRootWidget(FrostySdk.Ebx.UISpectatorRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

