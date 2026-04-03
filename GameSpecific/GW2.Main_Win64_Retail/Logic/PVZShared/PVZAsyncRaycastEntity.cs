using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAsyncRaycastEntityData))]
	public class PVZAsyncRaycastEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAsyncRaycastEntityData>
	{
		public new FrostySdk.Ebx.PVZAsyncRaycastEntityData Data => data as FrostySdk.Ebx.PVZAsyncRaycastEntityData;
		public override string DisplayName => "PVZAsyncRaycast";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAsyncRaycastEntity(FrostySdk.Ebx.PVZAsyncRaycastEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

