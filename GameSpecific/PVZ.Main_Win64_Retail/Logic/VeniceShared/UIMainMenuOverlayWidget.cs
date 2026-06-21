using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMainMenuOverlayWidgetData))]
	public class UIMainMenuOverlayWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMainMenuOverlayWidgetData>
	{
		public new FrostySdk.Ebx.UIMainMenuOverlayWidgetData Data => data as FrostySdk.Ebx.UIMainMenuOverlayWidgetData;
		public override string DisplayName => "UIMainMenuOverlayWidget";

		public UIMainMenuOverlayWidget(FrostySdk.Ebx.UIMainMenuOverlayWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

