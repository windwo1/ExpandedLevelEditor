using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorSquadPlayerWidgetData))]
	public class UISpectatorSquadPlayerWidget : UIHighlightWidget, IEntityData<FrostySdk.Ebx.UISpectatorSquadPlayerWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorSquadPlayerWidgetData Data => data as FrostySdk.Ebx.UISpectatorSquadPlayerWidgetData;
		public override string DisplayName => "UISpectatorSquadPlayerWidget";

		public UISpectatorSquadPlayerWidget(FrostySdk.Ebx.UISpectatorSquadPlayerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

