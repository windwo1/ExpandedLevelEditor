using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SpectatorEntityData))]
	public class SpectatorEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SpectatorEntityData>
	{
		public new FrostySdk.Ebx.SpectatorEntityData Data => data as FrostySdk.Ebx.SpectatorEntityData;
		public override string DisplayName => "Spectator";

		public SpectatorEntity(FrostySdk.Ebx.SpectatorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

