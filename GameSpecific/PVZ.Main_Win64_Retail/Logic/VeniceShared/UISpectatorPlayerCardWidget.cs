using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorPlayerCardWidgetData))]
	public class UISpectatorPlayerCardWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorPlayerCardWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorPlayerCardWidgetData Data => data as FrostySdk.Ebx.UISpectatorPlayerCardWidgetData;
		public override string DisplayName => "UISpectatorPlayerCardWidget";

		public UISpectatorPlayerCardWidget(FrostySdk.Ebx.UISpectatorPlayerCardWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

