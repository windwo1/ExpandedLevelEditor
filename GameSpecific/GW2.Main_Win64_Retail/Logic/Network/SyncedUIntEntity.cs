using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SyncedUIntEntityData))]
	public class SyncedUIntEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SyncedUIntEntityData>
	{
		public new FrostySdk.Ebx.SyncedUIntEntityData Data => data as FrostySdk.Ebx.SyncedUIntEntityData;
		public override string DisplayName => "SyncedUInt";

		public SyncedUIntEntity(FrostySdk.Ebx.SyncedUIntEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

