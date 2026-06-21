using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PromoteSquadActionData))]
	public class PromoteSquadAction : CommanderActionBase, IEntityData<FrostySdk.Ebx.PromoteSquadActionData>
	{
		public new FrostySdk.Ebx.PromoteSquadActionData Data => data as FrostySdk.Ebx.PromoteSquadActionData;
		public override string DisplayName => "PromoteSquadAction";

		public PromoteSquadAction(FrostySdk.Ebx.PromoteSquadActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

