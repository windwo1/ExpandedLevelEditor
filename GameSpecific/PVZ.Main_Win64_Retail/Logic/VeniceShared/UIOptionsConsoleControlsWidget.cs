using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIOptionsConsoleControlsWidgetData))]
	public class UIOptionsConsoleControlsWidget : UIOptionsListWidget, IEntityData<FrostySdk.Ebx.UIOptionsConsoleControlsWidgetData>
	{
		public new FrostySdk.Ebx.UIOptionsConsoleControlsWidgetData Data => data as FrostySdk.Ebx.UIOptionsConsoleControlsWidgetData;
		public override string DisplayName => "UIOptionsConsoleControlsWidget";

		public UIOptionsConsoleControlsWidget(FrostySdk.Ebx.UIOptionsConsoleControlsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

