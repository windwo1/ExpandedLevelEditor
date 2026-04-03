using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSyncedTimerEntityData))]
	public class PVZSyncedTimerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSyncedTimerEntityData>
	{
		public new FrostySdk.Ebx.PVZSyncedTimerEntityData Data => data as FrostySdk.Ebx.PVZSyncedTimerEntityData;
		public override string DisplayName => "PVZSyncedTimer";

		public PVZSyncedTimerEntity(FrostySdk.Ebx.PVZSyncedTimerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

