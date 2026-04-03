using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIControlSettingsEntityData))]
	public class PVZUIControlSettingsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIControlSettingsEntityData>
	{
		public new FrostySdk.Ebx.PVZUIControlSettingsEntityData Data => data as FrostySdk.Ebx.PVZUIControlSettingsEntityData;
		public override string DisplayName => "PVZUIControlSettings";

		public PVZUIControlSettingsEntity(FrostySdk.Ebx.PVZUIControlSettingsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

