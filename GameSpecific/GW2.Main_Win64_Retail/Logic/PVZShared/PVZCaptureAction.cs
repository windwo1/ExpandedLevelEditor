using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCaptureActionData))]
	public class PVZCaptureAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZCaptureActionData>
	{
		public new FrostySdk.Ebx.PVZCaptureActionData Data => data as FrostySdk.Ebx.PVZCaptureActionData;
		public override string DisplayName => "PVZCaptureAction";

		public PVZCaptureAction(FrostySdk.Ebx.PVZCaptureActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

