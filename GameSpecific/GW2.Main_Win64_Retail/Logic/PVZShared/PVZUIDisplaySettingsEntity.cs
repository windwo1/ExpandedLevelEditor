using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIDisplaySettingsEntityData))]
	public class PVZUIDisplaySettingsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIDisplaySettingsEntityData>
	{
		public new FrostySdk.Ebx.PVZUIDisplaySettingsEntityData Data => data as FrostySdk.Ebx.PVZUIDisplaySettingsEntityData;
		public override string DisplayName => "PVZUIDisplaySettings";

		public PVZUIDisplaySettingsEntity(FrostySdk.Ebx.PVZUIDisplaySettingsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

