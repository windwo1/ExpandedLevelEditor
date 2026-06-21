using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZGrenadeEntityData))]
	public class PVZGrenadeEntity : GrenadeEntity, IEntityData<FrostySdk.Ebx.PVZGrenadeEntityData>
	{
		public new FrostySdk.Ebx.PVZGrenadeEntityData Data => data as FrostySdk.Ebx.PVZGrenadeEntityData;

		public PVZGrenadeEntity(FrostySdk.Ebx.PVZGrenadeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

