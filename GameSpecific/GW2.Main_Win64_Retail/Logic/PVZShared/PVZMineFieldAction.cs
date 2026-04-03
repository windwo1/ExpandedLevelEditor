using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZMineFieldActionData))]
	public class PVZMineFieldAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZMineFieldActionData>
	{
		public new FrostySdk.Ebx.PVZMineFieldActionData Data => data as FrostySdk.Ebx.PVZMineFieldActionData;
		public override string DisplayName => "PVZMineFieldAction";

		public PVZMineFieldAction(FrostySdk.Ebx.PVZMineFieldActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

