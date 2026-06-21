using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMainMenuFriendsWidgetData))]
	public class UIMainMenuFriendsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMainMenuFriendsWidgetData>
	{
		public new FrostySdk.Ebx.UIMainMenuFriendsWidgetData Data => data as FrostySdk.Ebx.UIMainMenuFriendsWidgetData;
		public override string DisplayName => "UIMainMenuFriendsWidget";

		public UIMainMenuFriendsWidget(FrostySdk.Ebx.UIMainMenuFriendsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

