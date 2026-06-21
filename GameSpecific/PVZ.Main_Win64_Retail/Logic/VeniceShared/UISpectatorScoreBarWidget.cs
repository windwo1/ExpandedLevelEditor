using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorScoreBarWidgetData))]
	public class UISpectatorScoreBarWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorScoreBarWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorScoreBarWidgetData Data => data as FrostySdk.Ebx.UISpectatorScoreBarWidgetData;
		public override string DisplayName => "UISpectatorScoreBarWidget";

		public UISpectatorScoreBarWidget(FrostySdk.Ebx.UISpectatorScoreBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

