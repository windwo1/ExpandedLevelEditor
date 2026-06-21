using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIEmergencyTickerWidgetData))]
	public class UIEmergencyTickerWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIEmergencyTickerWidgetData>
	{
		public new FrostySdk.Ebx.UIEmergencyTickerWidgetData Data => data as FrostySdk.Ebx.UIEmergencyTickerWidgetData;
		public override string DisplayName => "UIEmergencyTickerWidget";

		public UIEmergencyTickerWidget(FrostySdk.Ebx.UIEmergencyTickerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

