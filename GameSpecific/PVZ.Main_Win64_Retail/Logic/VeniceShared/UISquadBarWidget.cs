using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISquadBarWidgetData))]
	public class UISquadBarWidget : UIProgressionBarWidget, IEntityData<FrostySdk.Ebx.UISquadBarWidgetData>
	{
		public new FrostySdk.Ebx.UISquadBarWidgetData Data => data as FrostySdk.Ebx.UISquadBarWidgetData;
		public override string DisplayName => "UISquadBarWidget";

		public UISquadBarWidget(FrostySdk.Ebx.UISquadBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

