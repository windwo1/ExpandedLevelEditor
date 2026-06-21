using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamEventEntityData))]
	public class TeamEventEntity : LogicEntity, IEntityData<FrostySdk.Ebx.TeamEventEntityData>
	{
		public new FrostySdk.Ebx.TeamEventEntityData Data => data as FrostySdk.Ebx.TeamEventEntityData;
		public override string DisplayName => "TeamEvent";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public TeamEventEntity(FrostySdk.Ebx.TeamEventEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

