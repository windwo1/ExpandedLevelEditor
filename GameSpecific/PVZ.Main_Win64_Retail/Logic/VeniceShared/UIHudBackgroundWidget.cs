using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIHudBackgroundWidgetData))]
	public class UIHudBackgroundWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIHudBackgroundWidgetData>
	{
		public new FrostySdk.Ebx.UIHudBackgroundWidgetData Data => data as FrostySdk.Ebx.UIHudBackgroundWidgetData;
		public override string DisplayName => "UIHudBackgroundWidget";

		public UIHudBackgroundWidget(FrostySdk.Ebx.UIHudBackgroundWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

