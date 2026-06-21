using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIScoreboardRootWidgetData))]
	public class UIScoreboardRootWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIScoreboardRootWidgetData>
	{
		public new FrostySdk.Ebx.UIScoreboardRootWidgetData Data => data as FrostySdk.Ebx.UIScoreboardRootWidgetData;
		public override string DisplayName => "UIScoreboardRootWidget";

		public UIScoreboardRootWidget(FrostySdk.Ebx.UIScoreboardRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

