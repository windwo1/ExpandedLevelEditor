using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorSelectorBarWidgetData))]
	public class UISpectatorSelectorBarWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorSelectorBarWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorSelectorBarWidgetData Data => data as FrostySdk.Ebx.UISpectatorSelectorBarWidgetData;
		public override string DisplayName => "UISpectatorSelectorBarWidget";

		public UISpectatorSelectorBarWidget(FrostySdk.Ebx.UISpectatorSelectorBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

