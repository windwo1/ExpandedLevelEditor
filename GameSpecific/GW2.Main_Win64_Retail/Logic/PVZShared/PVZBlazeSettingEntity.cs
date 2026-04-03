using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZBlazeSettingEntityData))]
	public class PVZBlazeSettingEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZBlazeSettingEntityData>
	{
		public new FrostySdk.Ebx.PVZBlazeSettingEntityData Data => data as FrostySdk.Ebx.PVZBlazeSettingEntityData;
		public override string DisplayName => "PVZBlazeSetting";

		public PVZBlazeSettingEntity(FrostySdk.Ebx.PVZBlazeSettingEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

