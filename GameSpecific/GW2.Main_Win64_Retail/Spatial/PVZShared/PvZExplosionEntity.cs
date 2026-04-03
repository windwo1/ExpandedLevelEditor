using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PvZExplosionEntityData))]
	public class PvZExplosionEntity : ExplosionEntity, IEntityData<FrostySdk.Ebx.PvZExplosionEntityData>
	{
		public new FrostySdk.Ebx.PvZExplosionEntityData Data => data as FrostySdk.Ebx.PvZExplosionEntityData;

		public PvZExplosionEntity(FrostySdk.Ebx.PvZExplosionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

