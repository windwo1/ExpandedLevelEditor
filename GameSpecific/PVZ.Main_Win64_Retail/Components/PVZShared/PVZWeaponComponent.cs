
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZWeaponComponentData))]
	public class PVZWeaponComponent : WeaponComponent, IEntityData<FrostySdk.Ebx.PVZWeaponComponentData>
	{
		public new FrostySdk.Ebx.PVZWeaponComponentData Data => data as FrostySdk.Ebx.PVZWeaponComponentData;
		public override string DisplayName => "PVZWeaponComponent";

		public PVZWeaponComponent(FrostySdk.Ebx.PVZWeaponComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

