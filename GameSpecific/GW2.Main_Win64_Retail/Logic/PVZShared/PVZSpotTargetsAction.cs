using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSpotTargetsActionData))]
	public class PVZSpotTargetsAction : PVZResurrectionAction, IEntityData<FrostySdk.Ebx.PVZSpotTargetsActionData>
	{
		public new FrostySdk.Ebx.PVZSpotTargetsActionData Data => data as FrostySdk.Ebx.PVZSpotTargetsActionData;
		public override string DisplayName => "PVZSpotTargetsAction";

		public PVZSpotTargetsAction(FrostySdk.Ebx.PVZSpotTargetsActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

