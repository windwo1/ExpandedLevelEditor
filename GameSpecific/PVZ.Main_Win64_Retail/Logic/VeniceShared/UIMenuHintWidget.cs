using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMenuHintWidgetData))]
	public class UIMenuHintWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMenuHintWidgetData>
	{
		public new FrostySdk.Ebx.UIMenuHintWidgetData Data => data as FrostySdk.Ebx.UIMenuHintWidgetData;
		public override string DisplayName => "UIMenuHintWidget";

		public UIMenuHintWidget(FrostySdk.Ebx.UIMenuHintWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

