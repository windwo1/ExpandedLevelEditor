using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIHudInventoryWidgetData))]
	public class UIHudInventoryWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIHudInventoryWidgetData>
	{
		public new FrostySdk.Ebx.UIHudInventoryWidgetData Data => data as FrostySdk.Ebx.UIHudInventoryWidgetData;
		public override string DisplayName => "UIHudInventoryWidget";

		public UIHudInventoryWidget(FrostySdk.Ebx.UIHudInventoryWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

