using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZFlyingNPCWaveActionData))]
	public class PVZFlyingNPCWaveAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZFlyingNPCWaveActionData>
	{
		public new FrostySdk.Ebx.PVZFlyingNPCWaveActionData Data => data as FrostySdk.Ebx.PVZFlyingNPCWaveActionData;
		public override string DisplayName => "PVZFlyingNPCWaveAction";

		public PVZFlyingNPCWaveAction(FrostySdk.Ebx.PVZFlyingNPCWaveActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

