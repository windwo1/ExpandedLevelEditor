using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISPFriendsLeaderboardWidgetData))]
	public class UISPFriendsLeaderboardWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISPFriendsLeaderboardWidgetData>
	{
		public new FrostySdk.Ebx.UISPFriendsLeaderboardWidgetData Data => data as FrostySdk.Ebx.UISPFriendsLeaderboardWidgetData;
		public override string DisplayName => "UISPFriendsLeaderboardWidget";

		public UISPFriendsLeaderboardWidget(FrostySdk.Ebx.UISPFriendsLeaderboardWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

