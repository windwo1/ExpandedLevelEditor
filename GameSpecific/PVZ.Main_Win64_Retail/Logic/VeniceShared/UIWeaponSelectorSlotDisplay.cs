using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIWeaponSelectorSlotDisplayData))]
	public class UIWeaponSelectorSlotDisplay : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIWeaponSelectorSlotDisplayData>
	{
		public new FrostySdk.Ebx.UIWeaponSelectorSlotDisplayData Data => data as FrostySdk.Ebx.UIWeaponSelectorSlotDisplayData;
		public override string DisplayName => "UIWeaponSelectorSlotDisplay";

		public UIWeaponSelectorSlotDisplay(FrostySdk.Ebx.UIWeaponSelectorSlotDisplayData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

