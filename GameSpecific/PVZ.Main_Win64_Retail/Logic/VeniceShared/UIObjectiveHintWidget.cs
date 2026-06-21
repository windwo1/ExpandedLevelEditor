using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectiveHintWidgetData))]
	public class UIObjectiveHintWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIObjectiveHintWidgetData>
	{
		public new FrostySdk.Ebx.UIObjectiveHintWidgetData Data => data as FrostySdk.Ebx.UIObjectiveHintWidgetData;
		public override string DisplayName => "UIObjectiveHintWidget";

		public UIObjectiveHintWidget(FrostySdk.Ebx.UIObjectiveHintWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

