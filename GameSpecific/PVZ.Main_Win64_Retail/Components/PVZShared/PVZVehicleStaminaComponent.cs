
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZVehicleStaminaComponentData))]
	public class PVZVehicleStaminaComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZVehicleStaminaComponentData>
	{
		public new FrostySdk.Ebx.PVZVehicleStaminaComponentData Data => data as FrostySdk.Ebx.PVZVehicleStaminaComponentData;
		public override string DisplayName => "PVZVehicleStaminaComponent";

		public PVZVehicleStaminaComponent(FrostySdk.Ebx.PVZVehicleStaminaComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

