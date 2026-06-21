using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIVehicleLoadoutSlotWidgetData))]
	public class UIVehicleLoadoutSlotWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIVehicleLoadoutSlotWidgetData>
	{
		public new FrostySdk.Ebx.UIVehicleLoadoutSlotWidgetData Data => data as FrostySdk.Ebx.UIVehicleLoadoutSlotWidgetData;
		public override string DisplayName => "UIVehicleLoadoutSlotWidget";

		public UIVehicleLoadoutSlotWidget(FrostySdk.Ebx.UIVehicleLoadoutSlotWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

