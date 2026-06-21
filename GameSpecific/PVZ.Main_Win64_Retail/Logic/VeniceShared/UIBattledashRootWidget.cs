using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashRootWidgetData))]
	public class UIBattledashRootWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashRootWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashRootWidgetData Data => data as FrostySdk.Ebx.UIBattledashRootWidgetData;
		public override string DisplayName => "UIBattledashRootWidget";

		public UIBattledashRootWidget(FrostySdk.Ebx.UIBattledashRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

