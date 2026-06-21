using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashChallengeDetailsWidgetData))]
	public class UIBattledashChallengeDetailsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashChallengeDetailsWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashChallengeDetailsWidgetData Data => data as FrostySdk.Ebx.UIBattledashChallengeDetailsWidgetData;
		public override string DisplayName => "UIBattledashChallengeDetailsWidget";

		public UIBattledashChallengeDetailsWidget(FrostySdk.Ebx.UIBattledashChallengeDetailsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

