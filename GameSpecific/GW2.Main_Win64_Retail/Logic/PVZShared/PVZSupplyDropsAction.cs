using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSupplyDropsActionData))]
	public class PVZSupplyDropsAction : PVZResurrectionAction, IEntityData<FrostySdk.Ebx.PVZSupplyDropsActionData>
	{
		public new FrostySdk.Ebx.PVZSupplyDropsActionData Data => data as FrostySdk.Ebx.PVZSupplyDropsActionData;
		public override string DisplayName => "PVZSupplyDropsAction";

		public PVZSupplyDropsAction(FrostySdk.Ebx.PVZSupplyDropsActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

