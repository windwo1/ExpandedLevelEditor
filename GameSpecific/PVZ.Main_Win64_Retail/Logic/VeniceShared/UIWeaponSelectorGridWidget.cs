using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIWeaponSelectorGridWidgetData))]
	public class UIWeaponSelectorGridWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIWeaponSelectorGridWidgetData>
	{
		public new FrostySdk.Ebx.UIWeaponSelectorGridWidgetData Data => data as FrostySdk.Ebx.UIWeaponSelectorGridWidgetData;
		public override string DisplayName => "UIWeaponSelectorGridWidget";

		public UIWeaponSelectorGridWidget(FrostySdk.Ebx.UIWeaponSelectorGridWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

