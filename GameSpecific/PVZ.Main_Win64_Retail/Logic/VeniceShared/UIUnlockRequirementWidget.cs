using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIUnlockRequirementWidgetData))]
	public class UIUnlockRequirementWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIUnlockRequirementWidgetData>
	{
		public new FrostySdk.Ebx.UIUnlockRequirementWidgetData Data => data as FrostySdk.Ebx.UIUnlockRequirementWidgetData;
		public override string DisplayName => "UIUnlockRequirementWidget";

		public UIUnlockRequirementWidget(FrostySdk.Ebx.UIUnlockRequirementWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

