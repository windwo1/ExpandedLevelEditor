using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectiveWidgetData))]
	public class UIObjectiveWidget : UIObjectiveWidgetBase, IEntityData<FrostySdk.Ebx.UIObjectiveWidgetData>
	{
		public new FrostySdk.Ebx.UIObjectiveWidgetData Data => data as FrostySdk.Ebx.UIObjectiveWidgetData;
		public override string DisplayName => "UIObjectiveWidget";

		public UIObjectiveWidget(FrostySdk.Ebx.UIObjectiveWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

