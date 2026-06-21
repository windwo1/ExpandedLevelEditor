using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBankAngleWidgetData))]
	public class UIBankAngleWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBankAngleWidgetData>
	{
		public new FrostySdk.Ebx.UIBankAngleWidgetData Data => data as FrostySdk.Ebx.UIBankAngleWidgetData;
		public override string DisplayName => "UIBankAngleWidget";

		public UIBankAngleWidget(FrostySdk.Ebx.UIBankAngleWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

