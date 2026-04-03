using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILeaderboardEntityData))]
	public class UILeaderboardEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UILeaderboardEntityData>
	{
		public new FrostySdk.Ebx.UILeaderboardEntityData Data => data as FrostySdk.Ebx.UILeaderboardEntityData;
		public override string DisplayName => "UILeaderboard";

		public UILeaderboardEntity(FrostySdk.Ebx.UILeaderboardEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

