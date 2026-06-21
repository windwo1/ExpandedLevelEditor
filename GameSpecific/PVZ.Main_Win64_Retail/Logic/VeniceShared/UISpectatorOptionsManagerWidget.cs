using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorOptionsManagerWidgetData))]
	public class UISpectatorOptionsManagerWidget : UIOptionsManagerWidget, IEntityData<FrostySdk.Ebx.UISpectatorOptionsManagerWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorOptionsManagerWidgetData Data => data as FrostySdk.Ebx.UISpectatorOptionsManagerWidgetData;
		public override string DisplayName => "UISpectatorOptionsManagerWidget";

		public UISpectatorOptionsManagerWidget(FrostySdk.Ebx.UISpectatorOptionsManagerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

