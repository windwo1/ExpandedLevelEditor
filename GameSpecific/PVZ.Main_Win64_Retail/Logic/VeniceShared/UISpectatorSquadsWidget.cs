using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorSquadsWidgetData))]
	public class UISpectatorSquadsWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorSquadsWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorSquadsWidgetData Data => data as FrostySdk.Ebx.UISpectatorSquadsWidgetData;
		public override string DisplayName => "UISpectatorSquadsWidget";

		public UISpectatorSquadsWidget(FrostySdk.Ebx.UISpectatorSquadsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

