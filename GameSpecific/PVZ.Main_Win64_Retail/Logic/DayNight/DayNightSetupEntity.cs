using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DayNightSetupEntityData))]
	public class DayNightSetupEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DayNightSetupEntityData>
	{
		public new FrostySdk.Ebx.DayNightSetupEntityData Data => data as FrostySdk.Ebx.DayNightSetupEntityData;
		public override string DisplayName => "DayNightSetup";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public DayNightSetupEntity(FrostySdk.Ebx.DayNightSetupEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

