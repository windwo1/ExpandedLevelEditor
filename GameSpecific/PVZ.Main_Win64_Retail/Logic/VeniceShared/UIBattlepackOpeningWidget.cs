using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattlepackOpeningWidgetData))]
	public class UIBattlepackOpeningWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattlepackOpeningWidgetData>
	{
		public new FrostySdk.Ebx.UIBattlepackOpeningWidgetData Data => data as FrostySdk.Ebx.UIBattlepackOpeningWidgetData;
		public override string DisplayName => "UIBattlepackOpeningWidget";

		public UIBattlepackOpeningWidget(FrostySdk.Ebx.UIBattlepackOpeningWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

