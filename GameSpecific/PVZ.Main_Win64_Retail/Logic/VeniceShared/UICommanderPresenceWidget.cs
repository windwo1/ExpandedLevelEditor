using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICommanderPresenceWidgetData))]
	public class UICommanderPresenceWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UICommanderPresenceWidgetData>
	{
		public new FrostySdk.Ebx.UICommanderPresenceWidgetData Data => data as FrostySdk.Ebx.UICommanderPresenceWidgetData;
		public override string DisplayName => "UICommanderPresenceWidget";

		public UICommanderPresenceWidget(FrostySdk.Ebx.UICommanderPresenceWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

