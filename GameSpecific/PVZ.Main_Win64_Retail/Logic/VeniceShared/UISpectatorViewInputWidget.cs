using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorViewInputWidgetData))]
	public class UISpectatorViewInputWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorViewInputWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorViewInputWidgetData Data => data as FrostySdk.Ebx.UISpectatorViewInputWidgetData;
		public override string DisplayName => "UISpectatorViewInputWidget";

		public UISpectatorViewInputWidget(FrostySdk.Ebx.UISpectatorViewInputWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

