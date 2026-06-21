using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIHudFloodFillWidgetData))]
	public class UIHudFloodFillWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIHudFloodFillWidgetData>
	{
		public new FrostySdk.Ebx.UIHudFloodFillWidgetData Data => data as FrostySdk.Ebx.UIHudFloodFillWidgetData;
		public override string DisplayName => "UIHudFloodFillWidget";

		public UIHudFloodFillWidget(FrostySdk.Ebx.UIHudFloodFillWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

