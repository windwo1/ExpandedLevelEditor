using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICommanderBarWidgetData))]
	public class UICommanderBarWidget : UIProgressionBarWidget, IEntityData<FrostySdk.Ebx.UICommanderBarWidgetData>
	{
		public new FrostySdk.Ebx.UICommanderBarWidgetData Data => data as FrostySdk.Ebx.UICommanderBarWidgetData;
		public override string DisplayName => "UICommanderBarWidget";

		public UICommanderBarWidget(FrostySdk.Ebx.UICommanderBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

