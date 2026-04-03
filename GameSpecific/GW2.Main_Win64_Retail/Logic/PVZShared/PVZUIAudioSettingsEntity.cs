using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIAudioSettingsEntityData))]
	public class PVZUIAudioSettingsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIAudioSettingsEntityData>
	{
		public new FrostySdk.Ebx.PVZUIAudioSettingsEntityData Data => data as FrostySdk.Ebx.PVZUIAudioSettingsEntityData;
		public override string DisplayName => "PVZUIAudioSettings";

		public PVZUIAudioSettingsEntity(FrostySdk.Ebx.PVZUIAudioSettingsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

