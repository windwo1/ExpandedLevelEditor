using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITabBarWidgetData))]
	public class UITabBarWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITabBarWidgetData>
	{
		public new FrostySdk.Ebx.UITabBarWidgetData Data => data as FrostySdk.Ebx.UITabBarWidgetData;
		public override string DisplayName => "UITabBarWidget";

		public UITabBarWidget(FrostySdk.Ebx.UITabBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

