using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashChallengesPageWidgetData))]
	public class UIBattledashChallengesPageWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashChallengesPageWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashChallengesPageWidgetData Data => data as FrostySdk.Ebx.UIBattledashChallengesPageWidgetData;
		public override string DisplayName => "UIBattledashChallengesPageWidget";

		public UIBattledashChallengesPageWidget(FrostySdk.Ebx.UIBattledashChallengesPageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

