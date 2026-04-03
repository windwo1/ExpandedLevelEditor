using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamSetupControlEntityData))]
	public class TeamSetupControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.TeamSetupControlEntityData>
	{
		public new FrostySdk.Ebx.TeamSetupControlEntityData Data => data as FrostySdk.Ebx.TeamSetupControlEntityData;
		public override string DisplayName => "TeamSetupControl";

		public TeamSetupControlEntity(FrostySdk.Ebx.TeamSetupControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

