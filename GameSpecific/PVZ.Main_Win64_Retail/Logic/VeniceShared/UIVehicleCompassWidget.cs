using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIVehicleCompassWidgetData))]
	public class UIVehicleCompassWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIVehicleCompassWidgetData>
	{
		public new FrostySdk.Ebx.UIVehicleCompassWidgetData Data => data as FrostySdk.Ebx.UIVehicleCompassWidgetData;
		public override string DisplayName => "UIVehicleCompassWidget";

		public UIVehicleCompassWidget(FrostySdk.Ebx.UIVehicleCompassWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

