
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSpottingCylinderComponentData))]
	public class PVZSpottingCylinderComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZSpottingCylinderComponentData>
	{
		public new FrostySdk.Ebx.PVZSpottingCylinderComponentData Data => data as FrostySdk.Ebx.PVZSpottingCylinderComponentData;
		public override string DisplayName => "PVZSpottingCylinderComponent";

		public PVZSpottingCylinderComponent(FrostySdk.Ebx.PVZSpottingCylinderComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

