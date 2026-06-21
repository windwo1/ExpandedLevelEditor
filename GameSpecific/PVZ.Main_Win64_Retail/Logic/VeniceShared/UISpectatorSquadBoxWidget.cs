using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorSquadBoxWidgetData))]
	public class UISpectatorSquadBoxWidget : UIHighlightWidget, IEntityData<FrostySdk.Ebx.UISpectatorSquadBoxWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorSquadBoxWidgetData Data => data as FrostySdk.Ebx.UISpectatorSquadBoxWidgetData;
		public override string DisplayName => "UISpectatorSquadBoxWidget";

		public UISpectatorSquadBoxWidget(FrostySdk.Ebx.UISpectatorSquadBoxWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

