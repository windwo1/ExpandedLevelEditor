using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattlescreenUIWidgetData))]
	public class UIBattlescreenUIWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattlescreenUIWidgetData>
	{
		public new FrostySdk.Ebx.UIBattlescreenUIWidgetData Data => data as FrostySdk.Ebx.UIBattlescreenUIWidgetData;
		public override string DisplayName => "UIBattlescreenUIWidget";

		public UIBattlescreenUIWidget(FrostySdk.Ebx.UIBattlescreenUIWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

