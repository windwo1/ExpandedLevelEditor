using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpectatorCameraBarWidgetData))]
	public class UISpectatorCameraBarWidget : UISpectatorWidget, IEntityData<FrostySdk.Ebx.UISpectatorCameraBarWidgetData>
	{
		public new FrostySdk.Ebx.UISpectatorCameraBarWidgetData Data => data as FrostySdk.Ebx.UISpectatorCameraBarWidgetData;
		public override string DisplayName => "UISpectatorCameraBarWidget";

		public UISpectatorCameraBarWidget(FrostySdk.Ebx.UISpectatorCameraBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

