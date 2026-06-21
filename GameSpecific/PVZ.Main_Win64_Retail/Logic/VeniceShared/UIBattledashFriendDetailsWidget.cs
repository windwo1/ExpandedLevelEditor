using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashFriendDetailsWidgetData))]
	public class UIBattledashFriendDetailsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashFriendDetailsWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashFriendDetailsWidgetData Data => data as FrostySdk.Ebx.UIBattledashFriendDetailsWidgetData;
		public override string DisplayName => "UIBattledashFriendDetailsWidget";

		public UIBattledashFriendDetailsWidget(FrostySdk.Ebx.UIBattledashFriendDetailsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

