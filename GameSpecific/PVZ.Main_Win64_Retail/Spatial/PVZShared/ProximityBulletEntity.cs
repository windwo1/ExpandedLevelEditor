using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProximityBulletEntityData))]
	public class ProximityBulletEntity : BulletEntity, IEntityData<FrostySdk.Ebx.ProximityBulletEntityData>
	{
		public new FrostySdk.Ebx.ProximityBulletEntityData Data => data as FrostySdk.Ebx.ProximityBulletEntityData;

		public ProximityBulletEntity(FrostySdk.Ebx.ProximityBulletEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

