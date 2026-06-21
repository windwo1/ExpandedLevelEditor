using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZLoadSyncEntityData))]
	public class PVZLoadSyncEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZLoadSyncEntityData>
	{
		public new FrostySdk.Ebx.PVZLoadSyncEntityData Data => data as FrostySdk.Ebx.PVZLoadSyncEntityData;
		public override string DisplayName => "PVZLoadSync";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZLoadSyncEntity(FrostySdk.Ebx.PVZLoadSyncEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

