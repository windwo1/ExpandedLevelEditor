using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorWidgetData))]
	public class UISpectatorWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISpectatorWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorWidgetData Data => data as FrostySdk.Ebx.UISpectatorWidgetData;
		public override string DisplayName => "UISpectatorWidget";

		public UISpectatorWidget(FrostySdk.Ebx.UISpectatorWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

