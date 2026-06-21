using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashFriendsPageWidgetData))]
	public class UIBattledashFriendsPageWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashFriendsPageWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashFriendsPageWidgetData Data => data as FrostySdk.Ebx.UIBattledashFriendsPageWidgetData;
		public override string DisplayName => "UIBattledashFriendsPageWidget";

		public UIBattledashFriendsPageWidget(FrostySdk.Ebx.UIBattledashFriendsPageWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

