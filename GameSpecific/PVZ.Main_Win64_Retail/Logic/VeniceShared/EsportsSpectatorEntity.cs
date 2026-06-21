using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.EsportsSpectatorEntityData))]
	public class EsportsSpectatorEntity : SpectatorEntity, IEntityData<FrostySdk.Ebx.EsportsSpectatorEntityData>
	{
		public new FrostySdk.Ebx.EsportsSpectatorEntityData Data => data as FrostySdk.Ebx.EsportsSpectatorEntityData;
		public override string DisplayName => "EsportsSpectator";

		public EsportsSpectatorEntity(FrostySdk.Ebx.EsportsSpectatorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

