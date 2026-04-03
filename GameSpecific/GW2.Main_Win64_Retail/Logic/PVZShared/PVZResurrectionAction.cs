using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZResurrectionActionData))]
	public class PVZResurrectionAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZResurrectionActionData>
	{
		public new FrostySdk.Ebx.PVZResurrectionActionData Data => data as FrostySdk.Ebx.PVZResurrectionActionData;
		public override string DisplayName => "PVZResurrectionAction";

		public PVZResurrectionAction(FrostySdk.Ebx.PVZResurrectionActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

