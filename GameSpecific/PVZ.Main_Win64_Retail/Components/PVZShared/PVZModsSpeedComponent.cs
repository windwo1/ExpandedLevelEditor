
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZModsSpeedComponentData))]
	public class PVZModsSpeedComponent : ModsSpeedComponent, IEntityData<FrostySdk.Ebx.PVZModsSpeedComponentData>
	{
		public new FrostySdk.Ebx.PVZModsSpeedComponentData Data => data as FrostySdk.Ebx.PVZModsSpeedComponentData;
		public override string DisplayName => "PVZModsSpeedComponent";

		public PVZModsSpeedComponent(FrostySdk.Ebx.PVZModsSpeedComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

