using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GhostProjectileTriggerFilterEntityData))]
	public class GhostProjectileTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.GhostProjectileTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.GhostProjectileTriggerFilterEntityData Data => data as FrostySdk.Ebx.GhostProjectileTriggerFilterEntityData;
		public override string DisplayName => "GhostProjectileTriggerFilter";

		public GhostProjectileTriggerFilterEntity(FrostySdk.Ebx.GhostProjectileTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

