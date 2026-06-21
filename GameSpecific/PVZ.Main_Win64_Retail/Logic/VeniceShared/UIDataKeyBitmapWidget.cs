using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDataKeyBitmapWidgetData))]
	public class UIDataKeyBitmapWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIDataKeyBitmapWidgetData>
	{
		public new FrostySdk.Ebx.UIDataKeyBitmapWidgetData Data => data as FrostySdk.Ebx.UIDataKeyBitmapWidgetData;
		public override string DisplayName => "UIDataKeyBitmapWidget";

		public UIDataKeyBitmapWidget(FrostySdk.Ebx.UIDataKeyBitmapWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

