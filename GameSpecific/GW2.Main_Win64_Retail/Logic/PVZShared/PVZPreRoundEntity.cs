using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPreRoundEntityData))]
	public class PVZPreRoundEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPreRoundEntityData>
	{
		public new FrostySdk.Ebx.PVZPreRoundEntityData Data => data as FrostySdk.Ebx.PVZPreRoundEntityData;
		public override string DisplayName => "PVZPreRound";

		public PVZPreRoundEntity(FrostySdk.Ebx.PVZPreRoundEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

