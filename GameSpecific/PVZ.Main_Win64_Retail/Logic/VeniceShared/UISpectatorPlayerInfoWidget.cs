using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorPlayerInfoWidgetData))]
	public class UISpectatorPlayerInfoWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorPlayerInfoWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorPlayerInfoWidgetData Data => data as FrostySdk.Ebx.UISpectatorPlayerInfoWidgetData;
		public override string DisplayName => "UISpectatorPlayerInfoWidget";

		public UISpectatorPlayerInfoWidget(FrostySdk.Ebx.UISpectatorPlayerInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

