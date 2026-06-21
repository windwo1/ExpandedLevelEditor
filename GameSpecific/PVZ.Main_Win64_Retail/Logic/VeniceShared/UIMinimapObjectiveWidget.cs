using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMinimapObjectiveWidgetData))]
	public class UIMinimapObjectiveWidget : UIObjectiveWidgetBase, IEntityData<FrostySdk.Ebx.UIMinimapObjectiveWidgetData>
	{
		public new FrostySdk.Ebx.UIMinimapObjectiveWidgetData Data => data as FrostySdk.Ebx.UIMinimapObjectiveWidgetData;
		public override string DisplayName => "UIMinimapObjectiveWidget";

		public UIMinimapObjectiveWidget(FrostySdk.Ebx.UIMinimapObjectiveWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

