using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZBoneCollisionEntityData))]
	public class PVZBoneCollisionEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZBoneCollisionEntityData>
	{
		public new FrostySdk.Ebx.PVZBoneCollisionEntityData Data => data as FrostySdk.Ebx.PVZBoneCollisionEntityData;
		public override string DisplayName => "PVZBoneCollision";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZBoneCollisionEntity(FrostySdk.Ebx.PVZBoneCollisionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

