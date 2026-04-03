using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZBasicTimerEntityData))]
	public class PVZBasicTimerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZBasicTimerEntityData>
	{
		public new FrostySdk.Ebx.PVZBasicTimerEntityData Data => data as FrostySdk.Ebx.PVZBasicTimerEntityData;
		public override string DisplayName => "PVZBasicTimer";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZBasicTimerEntity(FrostySdk.Ebx.PVZBasicTimerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

