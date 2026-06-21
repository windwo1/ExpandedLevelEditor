using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamTriggerFilterEntityData))]
	public class TeamTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.TeamTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.TeamTriggerFilterEntityData Data => data as FrostySdk.Ebx.TeamTriggerFilterEntityData;
		public override string DisplayName => "TeamTriggerFilter";

		public TeamTriggerFilterEntity(FrostySdk.Ebx.TeamTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

