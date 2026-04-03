
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZVehicleEntryComponentData))]
	public class PVZVehicleEntryComponent : VehicleEntryComponent, IEntityData<FrostySdk.Ebx.PVZVehicleEntryComponentData>
	{
		public new FrostySdk.Ebx.PVZVehicleEntryComponentData Data => data as FrostySdk.Ebx.PVZVehicleEntryComponentData;
		public override string DisplayName => "PVZVehicleEntryComponent";

		public PVZVehicleEntryComponent(FrostySdk.Ebx.PVZVehicleEntryComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

