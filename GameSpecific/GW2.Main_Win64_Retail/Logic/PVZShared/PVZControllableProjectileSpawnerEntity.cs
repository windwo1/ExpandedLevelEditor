using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZControllableProjectileSpawnerEntityData))]
	public class PVZControllableProjectileSpawnerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZControllableProjectileSpawnerEntityData>
	{
		public new FrostySdk.Ebx.PVZControllableProjectileSpawnerEntityData Data => data as FrostySdk.Ebx.PVZControllableProjectileSpawnerEntityData;
		public override string DisplayName => "PVZControllableProjectileSpawner";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZControllableProjectileSpawnerEntity(FrostySdk.Ebx.PVZControllableProjectileSpawnerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

