using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashHomeWidgetData))]
	public class UIBattledashHomeWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashHomeWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashHomeWidgetData Data => data as FrostySdk.Ebx.UIBattledashHomeWidgetData;
		public override string DisplayName => "UIBattledashHomeWidget";

		public UIBattledashHomeWidget(FrostySdk.Ebx.UIBattledashHomeWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

