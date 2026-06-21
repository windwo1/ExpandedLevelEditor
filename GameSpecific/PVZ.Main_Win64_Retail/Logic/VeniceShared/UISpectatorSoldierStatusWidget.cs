using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorSoldierStatusWidgetData))]
	public class UISpectatorSoldierStatusWidget : UISoldierStatusWidget, IEntityData<FrostySdk.Ebx.UISpectatorSoldierStatusWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorSoldierStatusWidgetData Data => data as FrostySdk.Ebx.UISpectatorSoldierStatusWidgetData;
		public override string DisplayName => "UISpectatorSoldierStatusWidget";

		public UISpectatorSoldierStatusWidget(FrostySdk.Ebx.UISpectatorSoldierStatusWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

