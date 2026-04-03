using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SphereBulletEntityData))]
	public class SphereBulletEntity : BulletEntity, IEntityData<FrostySdk.Ebx.SphereBulletEntityData>
	{
		public new FrostySdk.Ebx.SphereBulletEntityData Data => data as FrostySdk.Ebx.SphereBulletEntityData;

		public SphereBulletEntity(FrostySdk.Ebx.SphereBulletEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

