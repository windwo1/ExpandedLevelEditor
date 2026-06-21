using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIInputDebuggingWidgetData))]
	public class UIInputDebuggingWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIInputDebuggingWidgetData>
	{
		public new FrostySdk.Ebx.UIInputDebuggingWidgetData Data => data as FrostySdk.Ebx.UIInputDebuggingWidgetData;
		public override string DisplayName => "UIInputDebuggingWidget";

		public UIInputDebuggingWidget(FrostySdk.Ebx.UIInputDebuggingWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

