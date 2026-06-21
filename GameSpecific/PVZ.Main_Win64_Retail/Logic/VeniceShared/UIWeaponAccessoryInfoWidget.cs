using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIWeaponAccessoryInfoWidgetData))]
	public class UIWeaponAccessoryInfoWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIWeaponAccessoryInfoWidgetData>
	{
		public new FrostySdk.Ebx.UIWeaponAccessoryInfoWidgetData Data => data as FrostySdk.Ebx.UIWeaponAccessoryInfoWidgetData;
		public override string DisplayName => "UIWeaponAccessoryInfoWidget";

		public UIWeaponAccessoryInfoWidget(FrostySdk.Ebx.UIWeaponAccessoryInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

