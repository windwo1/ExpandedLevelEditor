using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAirStrikeActionData))]
	public class PVZAirStrikeAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZAirStrikeActionData>
	{
		public new FrostySdk.Ebx.PVZAirStrikeActionData Data => data as FrostySdk.Ebx.PVZAirStrikeActionData;
		public override string DisplayName => "PVZAirStrikeAction";

		public PVZAirStrikeAction(FrostySdk.Ebx.PVZAirStrikeActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

