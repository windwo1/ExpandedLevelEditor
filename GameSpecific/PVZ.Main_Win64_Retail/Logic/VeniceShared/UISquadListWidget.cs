using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISquadListWidgetData))]
	public class UISquadListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISquadListWidgetData>
	{
		public new FrostySdk.Ebx.UISquadListWidgetData Data => data as FrostySdk.Ebx.UISquadListWidgetData;
		public override string DisplayName => "UISquadListWidget";

		public UISquadListWidget(FrostySdk.Ebx.UISquadListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

