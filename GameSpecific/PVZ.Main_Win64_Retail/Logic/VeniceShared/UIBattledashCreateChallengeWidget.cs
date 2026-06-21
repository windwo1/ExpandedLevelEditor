using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashCreateChallengeWidgetData))]
	public class UIBattledashCreateChallengeWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashCreateChallengeWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashCreateChallengeWidgetData Data => data as FrostySdk.Ebx.UIBattledashCreateChallengeWidgetData;
		public override string DisplayName => "UIBattledashCreateChallengeWidget";

		public UIBattledashCreateChallengeWidget(FrostySdk.Ebx.UIBattledashCreateChallengeWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

