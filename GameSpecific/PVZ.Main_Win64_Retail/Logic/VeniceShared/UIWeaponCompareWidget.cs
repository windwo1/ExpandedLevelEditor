using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIWeaponCompareWidgetData))]
	public class UIWeaponCompareWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIWeaponCompareWidgetData>
	{
		public new FrostySdk.Ebx.UIWeaponCompareWidgetData Data => data as FrostySdk.Ebx.UIWeaponCompareWidgetData;
		public override string DisplayName => "UIWeaponCompareWidget";

		public UIWeaponCompareWidget(FrostySdk.Ebx.UIWeaponCompareWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

