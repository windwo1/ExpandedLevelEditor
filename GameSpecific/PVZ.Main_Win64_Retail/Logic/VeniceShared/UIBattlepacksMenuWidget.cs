using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattlepacksMenuWidgetData))]
	public class UIBattlepacksMenuWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattlepacksMenuWidgetData>
	{
		public new FrostySdk.Ebx.UIBattlepacksMenuWidgetData Data => data as FrostySdk.Ebx.UIBattlepacksMenuWidgetData;
		public override string DisplayName => "UIBattlepacksMenuWidget";

		public UIBattlepacksMenuWidget(FrostySdk.Ebx.UIBattlepacksMenuWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

