using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZKillCounterEntityData))]
	public class PVZKillCounterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZKillCounterEntityData>
	{
		public new FrostySdk.Ebx.PVZKillCounterEntityData Data => data as FrostySdk.Ebx.PVZKillCounterEntityData;
		public override string DisplayName => "PVZKillCounter";

		public PVZKillCounterEntity(FrostySdk.Ebx.PVZKillCounterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

