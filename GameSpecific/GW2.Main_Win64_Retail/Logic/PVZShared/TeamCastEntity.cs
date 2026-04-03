using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamCastEntityData))]
	public class TeamCastEntity : LogicEntity, IEntityData<FrostySdk.Ebx.TeamCastEntityData>
	{
		public new FrostySdk.Ebx.TeamCastEntityData Data => data as FrostySdk.Ebx.TeamCastEntityData;
		public override string DisplayName => "TeamCast";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public TeamCastEntity(FrostySdk.Ebx.TeamCastEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

