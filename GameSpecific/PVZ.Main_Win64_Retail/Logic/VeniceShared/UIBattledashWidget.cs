using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashWidgetData))]
	public class UIBattledashWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashWidgetData Data => data as FrostySdk.Ebx.UIBattledashWidgetData;
		public override string DisplayName => "UIBattledashWidget";

		public UIBattledashWidget(FrostySdk.Ebx.UIBattledashWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

