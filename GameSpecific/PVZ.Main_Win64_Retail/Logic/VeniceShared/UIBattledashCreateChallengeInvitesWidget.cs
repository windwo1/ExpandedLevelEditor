using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashCreateChallengeInvitesWidgetData))]
	public class UIBattledashCreateChallengeInvitesWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashCreateChallengeInvitesWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashCreateChallengeInvitesWidgetData Data => data as FrostySdk.Ebx.UIBattledashCreateChallengeInvitesWidgetData;
		public override string DisplayName => "UIBattledashCreateChallengeInvitesWidget";

		public UIBattledashCreateChallengeInvitesWidget(FrostySdk.Ebx.UIBattledashCreateChallengeInvitesWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

