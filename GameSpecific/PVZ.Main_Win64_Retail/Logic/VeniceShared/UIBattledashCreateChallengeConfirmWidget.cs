using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashCreateChallengeConfirmWidgetData))]
	public class UIBattledashCreateChallengeConfirmWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashCreateChallengeConfirmWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashCreateChallengeConfirmWidgetData Data => data as FrostySdk.Ebx.UIBattledashCreateChallengeConfirmWidgetData;
		public override string DisplayName => "UIBattledashCreateChallengeConfirmWidget";

		public UIBattledashCreateChallengeConfirmWidget(FrostySdk.Ebx.UIBattledashCreateChallengeConfirmWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

