
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZVehicleWeaponComponentData))]
	public class PVZVehicleWeaponComponent : WeaponComponent, IEntityData<FrostySdk.Ebx.PVZVehicleWeaponComponentData>
	{
		public new FrostySdk.Ebx.PVZVehicleWeaponComponentData Data => data as FrostySdk.Ebx.PVZVehicleWeaponComponentData;
		public override string DisplayName => "PVZVehicleWeaponComponent";

		public PVZVehicleWeaponComponent(FrostySdk.Ebx.PVZVehicleWeaponComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

