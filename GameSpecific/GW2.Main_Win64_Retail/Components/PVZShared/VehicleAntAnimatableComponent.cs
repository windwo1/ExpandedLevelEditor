
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.VehicleAntAnimatableComponentData))]
	public class VehicleAntAnimatableComponent : GameComponent, IEntityData<FrostySdk.Ebx.VehicleAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.VehicleAntAnimatableComponentData Data => data as FrostySdk.Ebx.VehicleAntAnimatableComponentData;
		public override string DisplayName => "VehicleAntAnimatableComponent";

		public VehicleAntAnimatableComponent(FrostySdk.Ebx.VehicleAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

