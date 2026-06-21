using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashPlaygroupPageWidgetData))]
	public class UIBattledashPlaygroupPageWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashPlaygroupPageWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashPlaygroupPageWidgetData Data => data as FrostySdk.Ebx.UIBattledashPlaygroupPageWidgetData;
		public override string DisplayName => "UIBattledashPlaygroupPageWidget";

		public UIBattledashPlaygroupPageWidget(FrostySdk.Ebx.UIBattledashPlaygroupPageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

