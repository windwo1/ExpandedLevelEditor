
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSpottingComponentData))]
	public class PVZSpottingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZSpottingComponentData>
	{
		public new FrostySdk.Ebx.PVZSpottingComponentData Data => data as FrostySdk.Ebx.PVZSpottingComponentData;
		public override string DisplayName => "PVZSpottingComponent";

		public PVZSpottingComponent(FrostySdk.Ebx.PVZSpottingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

