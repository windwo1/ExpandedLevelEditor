using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZTimerEntityData))]
	public class PVZTimerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZTimerEntityData>
	{
		public new FrostySdk.Ebx.PVZTimerEntityData Data => data as FrostySdk.Ebx.PVZTimerEntityData;
		public override string DisplayName => "PVZTimer";

		public PVZTimerEntity(FrostySdk.Ebx.PVZTimerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

