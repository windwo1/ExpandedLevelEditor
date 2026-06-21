using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashHListWidgetData))]
	public class UIBattledashHListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashHListWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashHListWidgetData Data => data as FrostySdk.Ebx.UIBattledashHListWidgetData;
		public override string DisplayName => "UIBattledashHListWidget";

		public UIBattledashHListWidget(FrostySdk.Ebx.UIBattledashHListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

