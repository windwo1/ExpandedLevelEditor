using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorPlayerBarWidgetData))]
	public class UISpectatorPlayerBarWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorPlayerBarWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorPlayerBarWidgetData Data => data as FrostySdk.Ebx.UISpectatorPlayerBarWidgetData;
		public override string DisplayName => "UISpectatorPlayerBarWidget";

		public UISpectatorPlayerBarWidget(FrostySdk.Ebx.UISpectatorPlayerBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

