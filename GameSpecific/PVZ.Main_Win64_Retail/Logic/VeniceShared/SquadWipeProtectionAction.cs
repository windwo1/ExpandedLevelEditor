using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SquadWipeProtectionActionData))]
	public class SquadWipeProtectionAction : CommanderActionBase, IEntityData<FrostySdk.Ebx.SquadWipeProtectionActionData>
	{
		public new FrostySdk.Ebx.SquadWipeProtectionActionData Data => data as FrostySdk.Ebx.SquadWipeProtectionActionData;
		public override string DisplayName => "SquadWipeProtectionAction";

		public SquadWipeProtectionAction(FrostySdk.Ebx.SquadWipeProtectionActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

