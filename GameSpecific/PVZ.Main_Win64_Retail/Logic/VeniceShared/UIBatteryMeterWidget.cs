using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBatteryMeterWidgetData))]
	public class UIBatteryMeterWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBatteryMeterWidgetData>
	{
		public new FrostySdk.Ebx.UIBatteryMeterWidgetData Data => data as FrostySdk.Ebx.UIBatteryMeterWidgetData;
		public override string DisplayName => "UIBatteryMeterWidget";

		public UIBatteryMeterWidget(FrostySdk.Ebx.UIBatteryMeterWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

