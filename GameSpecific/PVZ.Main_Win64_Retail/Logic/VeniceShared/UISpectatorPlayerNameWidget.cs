using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorPlayerNameWidgetData))]
	public class UISpectatorPlayerNameWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISpectatorPlayerNameWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorPlayerNameWidgetData Data => data as FrostySdk.Ebx.UISpectatorPlayerNameWidgetData;
		public override string DisplayName => "UISpectatorPlayerNameWidget";

		public UISpectatorPlayerNameWidget(FrostySdk.Ebx.UISpectatorPlayerNameWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

