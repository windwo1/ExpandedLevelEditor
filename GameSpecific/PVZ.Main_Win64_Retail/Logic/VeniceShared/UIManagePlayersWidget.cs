using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIManagePlayersWidgetData))]
	public class UIManagePlayersWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIManagePlayersWidgetData>
	{
		public new FrostySdk.Ebx.UIManagePlayersWidgetData Data => data as FrostySdk.Ebx.UIManagePlayersWidgetData;
		public override string DisplayName => "UIManagePlayersWidget";

		public UIManagePlayersWidget(FrostySdk.Ebx.UIManagePlayersWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

