using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIScoreboardWidgetData))]
	public class UIScoreboardWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIScoreboardWidgetData>
	{
		public new FrostySdk.Ebx.UIScoreboardWidgetData Data => data as FrostySdk.Ebx.UIScoreboardWidgetData;
		public override string DisplayName => "UIScoreboardWidget";

		public UIScoreboardWidget(FrostySdk.Ebx.UIScoreboardWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

