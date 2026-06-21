using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIEndOfRoundEntityData))]
	public class PVZUIEndOfRoundEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIEndOfRoundEntityData>
	{
		public new FrostySdk.Ebx.PVZUIEndOfRoundEntityData Data => data as FrostySdk.Ebx.PVZUIEndOfRoundEntityData;
		public override string DisplayName => "PVZUIEndOfRound";

		public PVZUIEndOfRoundEntity(FrostySdk.Ebx.PVZUIEndOfRoundEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

