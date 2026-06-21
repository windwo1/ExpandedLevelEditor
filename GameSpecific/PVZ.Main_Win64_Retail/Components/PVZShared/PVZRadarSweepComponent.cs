
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZRadarSweepComponentData))]
	public class PVZRadarSweepComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZRadarSweepComponentData>
	{
		public new FrostySdk.Ebx.PVZRadarSweepComponentData Data => data as FrostySdk.Ebx.PVZRadarSweepComponentData;
		public override string DisplayName => "PVZRadarSweepComponent";

		public PVZRadarSweepComponent(FrostySdk.Ebx.PVZRadarSweepComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

