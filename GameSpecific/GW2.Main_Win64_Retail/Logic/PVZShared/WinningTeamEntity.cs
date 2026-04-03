using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WinningTeamEntityData))]
	public class WinningTeamEntity : LogicEntity, IEntityData<FrostySdk.Ebx.WinningTeamEntityData>
	{
		public new FrostySdk.Ebx.WinningTeamEntityData Data => data as FrostySdk.Ebx.WinningTeamEntityData;
		public override string DisplayName => "WinningTeam";

		public WinningTeamEntity(FrostySdk.Ebx.WinningTeamEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

