using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZGameInteractionEntityData))]
	public class PVZGameInteractionEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.PVZGameInteractionEntityData>
	{
		public new FrostySdk.Ebx.PVZGameInteractionEntityData Data => data as FrostySdk.Ebx.PVZGameInteractionEntityData;

		public PVZGameInteractionEntity(FrostySdk.Ebx.PVZGameInteractionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

