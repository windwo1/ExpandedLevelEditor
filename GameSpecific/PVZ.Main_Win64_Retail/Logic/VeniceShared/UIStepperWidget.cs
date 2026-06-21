using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStepperWidgetData))]
	public class UIStepperWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIStepperWidgetData>
	{
		public new FrostySdk.Ebx.UIStepperWidgetData Data => data as FrostySdk.Ebx.UIStepperWidgetData;
		public override string DisplayName => "UIStepperWidget";

		public UIStepperWidget(FrostySdk.Ebx.UIStepperWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

