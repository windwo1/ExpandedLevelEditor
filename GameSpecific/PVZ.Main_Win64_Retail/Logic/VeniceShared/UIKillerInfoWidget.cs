using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKillerInfoWidgetData))]
	public class UIKillerInfoWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIKillerInfoWidgetData>
	{
		public new FrostySdk.Ebx.UIKillerInfoWidgetData Data => data as FrostySdk.Ebx.UIKillerInfoWidgetData;
		public override string DisplayName => "UIKillerInfoWidget";

		public UIKillerInfoWidget(FrostySdk.Ebx.UIKillerInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

