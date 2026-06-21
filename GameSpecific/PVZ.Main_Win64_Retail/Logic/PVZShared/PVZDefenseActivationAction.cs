using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZDefenseActivationActionData))]
	public class PVZDefenseActivationAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZDefenseActivationActionData>
	{
		public new FrostySdk.Ebx.PVZDefenseActivationActionData Data => data as FrostySdk.Ebx.PVZDefenseActivationActionData;
		public override string DisplayName => "PVZDefenseActivationAction";

		public PVZDefenseActivationAction(FrostySdk.Ebx.PVZDefenseActivationActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

