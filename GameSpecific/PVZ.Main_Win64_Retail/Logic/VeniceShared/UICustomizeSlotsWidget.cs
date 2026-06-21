using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICustomizeSlotsWidgetData))]
	public class UICustomizeSlotsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UICustomizeSlotsWidgetData>
	{
		public new FrostySdk.Ebx.UICustomizeSlotsWidgetData Data => data as FrostySdk.Ebx.UICustomizeSlotsWidgetData;
		public override string DisplayName => "UICustomizeSlotsWidget";

		public UICustomizeSlotsWidget(FrostySdk.Ebx.UICustomizeSlotsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

