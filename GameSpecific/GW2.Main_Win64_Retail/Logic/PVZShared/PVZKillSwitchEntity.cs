using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZKillSwitchEntityData))]
	public class PVZKillSwitchEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZKillSwitchEntityData>
	{
		public new FrostySdk.Ebx.PVZKillSwitchEntityData Data => data as FrostySdk.Ebx.PVZKillSwitchEntityData;
		public override string DisplayName => "PVZKillSwitch";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZKillSwitchEntity(FrostySdk.Ebx.PVZKillSwitchEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

