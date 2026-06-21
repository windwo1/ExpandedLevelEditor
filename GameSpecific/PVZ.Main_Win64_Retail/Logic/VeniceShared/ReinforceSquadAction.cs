using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ReinforceSquadActionData))]
	public class ReinforceSquadAction : CommanderActionBase, IEntityData<FrostySdk.Ebx.ReinforceSquadActionData>
	{
		public new FrostySdk.Ebx.ReinforceSquadActionData Data => data as FrostySdk.Ebx.ReinforceSquadActionData;
		public override string DisplayName => "ReinforceSquadAction";

		public ReinforceSquadAction(FrostySdk.Ebx.ReinforceSquadActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

