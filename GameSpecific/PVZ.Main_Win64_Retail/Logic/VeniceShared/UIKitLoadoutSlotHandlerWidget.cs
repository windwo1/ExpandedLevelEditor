using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKitLoadoutSlotHandlerWidgetData))]
	public class UIKitLoadoutSlotHandlerWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIKitLoadoutSlotHandlerWidgetData>
	{
		public new FrostySdk.Ebx.UIKitLoadoutSlotHandlerWidgetData Data => data as FrostySdk.Ebx.UIKitLoadoutSlotHandlerWidgetData;
		public override string DisplayName => "UIKitLoadoutSlotHandlerWidget";

		public UIKitLoadoutSlotHandlerWidget(FrostySdk.Ebx.UIKitLoadoutSlotHandlerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

