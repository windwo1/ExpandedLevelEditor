using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZArtilleryStrikeGrenadeEntityData))]
	public class PVZArtilleryStrikeGrenadeEntity : GrenadeEntity, IEntityData<FrostySdk.Ebx.PVZArtilleryStrikeGrenadeEntityData>
	{
		public new FrostySdk.Ebx.PVZArtilleryStrikeGrenadeEntityData Data => data as FrostySdk.Ebx.PVZArtilleryStrikeGrenadeEntityData;

		public PVZArtilleryStrikeGrenadeEntity(FrostySdk.Ebx.PVZArtilleryStrikeGrenadeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

