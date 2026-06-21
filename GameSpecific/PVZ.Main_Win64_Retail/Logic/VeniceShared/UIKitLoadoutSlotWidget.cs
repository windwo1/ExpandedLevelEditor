using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKitLoadoutSlotWidgetData))]
	public class UIKitLoadoutSlotWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIKitLoadoutSlotWidgetData>
	{
		public new FrostySdk.Ebx.UIKitLoadoutSlotWidgetData Data => data as FrostySdk.Ebx.UIKitLoadoutSlotWidgetData;
		public override string DisplayName => "UIKitLoadoutSlotWidget";

		public UIKitLoadoutSlotWidget(FrostySdk.Ebx.UIKitLoadoutSlotWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

