using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILongTextWidgetData))]
	public class UILongTextWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UILongTextWidgetData>
	{
		public new FrostySdk.Ebx.UILongTextWidgetData Data => data as FrostySdk.Ebx.UILongTextWidgetData;
		public override string DisplayName => "UILongTextWidget";

		public UILongTextWidget(FrostySdk.Ebx.UILongTextWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

