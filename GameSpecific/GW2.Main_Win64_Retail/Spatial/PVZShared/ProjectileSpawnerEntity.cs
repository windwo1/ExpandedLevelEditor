using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProjectileSpawnerEntityData))]
	public class ProjectileSpawnerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.ProjectileSpawnerEntityData>
	{
		public new FrostySdk.Ebx.ProjectileSpawnerEntityData Data => data as FrostySdk.Ebx.ProjectileSpawnerEntityData;

		public ProjectileSpawnerEntity(FrostySdk.Ebx.ProjectileSpawnerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

