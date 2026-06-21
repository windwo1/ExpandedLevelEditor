using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITitanScoringInfoWidgetData))]
	public class UITitanScoringInfoWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITitanScoringInfoWidgetData>
	{
		public new FrostySdk.Ebx.UITitanScoringInfoWidgetData Data => data as FrostySdk.Ebx.UITitanScoringInfoWidgetData;
		public override string DisplayName => "UITitanScoringInfoWidget";

		public UITitanScoringInfoWidget(FrostySdk.Ebx.UITitanScoringInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

