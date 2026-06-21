using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMainMenuCommerceWidgetData))]
	public class UIMainMenuCommerceWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMainMenuCommerceWidgetData>
	{
		public new FrostySdk.Ebx.UIMainMenuCommerceWidgetData Data => data as FrostySdk.Ebx.UIMainMenuCommerceWidgetData;
		public override string DisplayName => "UIMainMenuCommerceWidget";

		public UIMainMenuCommerceWidget(FrostySdk.Ebx.UIMainMenuCommerceWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

