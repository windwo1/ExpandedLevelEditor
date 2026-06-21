
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSpottingTargetComponentData))]
	public class PVZSpottingTargetComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZSpottingTargetComponentData>
	{
		public new FrostySdk.Ebx.PVZSpottingTargetComponentData Data => data as FrostySdk.Ebx.PVZSpottingTargetComponentData;
		public override string DisplayName => "PVZSpottingTargetComponent";

		public PVZSpottingTargetComponent(FrostySdk.Ebx.PVZSpottingTargetComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

