using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashAutoListWidgetData))]
	public class UIBattledashAutoListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashAutoListWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashAutoListWidgetData Data => data as FrostySdk.Ebx.UIBattledashAutoListWidgetData;
		public override string DisplayName => "UIBattledashAutoListWidget";

		public UIBattledashAutoListWidget(FrostySdk.Ebx.UIBattledashAutoListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

