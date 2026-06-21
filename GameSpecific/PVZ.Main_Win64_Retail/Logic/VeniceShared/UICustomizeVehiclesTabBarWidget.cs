using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICustomizeVehiclesTabBarWidgetData))]
	public class UICustomizeVehiclesTabBarWidget : UITabBarWidget, IEntityData<FrostySdk.Ebx.UICustomizeVehiclesTabBarWidgetData>
	{
		public new FrostySdk.Ebx.UICustomizeVehiclesTabBarWidgetData Data => data as FrostySdk.Ebx.UICustomizeVehiclesTabBarWidgetData;
		public override string DisplayName => "UICustomizeVehiclesTabBarWidget";

		public UICustomizeVehiclesTabBarWidget(FrostySdk.Ebx.UICustomizeVehiclesTabBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

