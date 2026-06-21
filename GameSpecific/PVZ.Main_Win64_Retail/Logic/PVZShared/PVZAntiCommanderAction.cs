using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAntiCommanderActionData))]
	public class PVZAntiCommanderAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZAntiCommanderActionData>
	{
		public new FrostySdk.Ebx.PVZAntiCommanderActionData Data => data as FrostySdk.Ebx.PVZAntiCommanderActionData;
		public override string DisplayName => "PVZAntiCommanderAction";

		public PVZAntiCommanderAction(FrostySdk.Ebx.PVZAntiCommanderActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

