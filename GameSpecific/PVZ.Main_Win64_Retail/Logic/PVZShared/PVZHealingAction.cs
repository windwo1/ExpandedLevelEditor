using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZHealingActionData))]
	public class PVZHealingAction : PVZResurrectionAction, IEntityData<FrostySdk.Ebx.PVZHealingActionData>
	{
		public new FrostySdk.Ebx.PVZHealingActionData Data => data as FrostySdk.Ebx.PVZHealingActionData;
		public override string DisplayName => "PVZHealingAction";

		public PVZHealingAction(FrostySdk.Ebx.PVZHealingActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

