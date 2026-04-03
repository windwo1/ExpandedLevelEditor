using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZRoundOverEntityData))]
	public class PVZRoundOverEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZRoundOverEntityData>
	{
		public new FrostySdk.Ebx.PVZRoundOverEntityData Data => data as FrostySdk.Ebx.PVZRoundOverEntityData;
		public override string DisplayName => "PVZRoundOver";

		public PVZRoundOverEntity(FrostySdk.Ebx.PVZRoundOverEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

