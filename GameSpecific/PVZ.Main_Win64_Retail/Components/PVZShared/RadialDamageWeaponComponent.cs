
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RadialDamageWeaponComponentData))]
	public class RadialDamageWeaponComponent : GameComponent, IEntityData<FrostySdk.Ebx.RadialDamageWeaponComponentData>
	{
		public new FrostySdk.Ebx.RadialDamageWeaponComponentData Data => data as FrostySdk.Ebx.RadialDamageWeaponComponentData;
		public override string DisplayName => "RadialDamageWeaponComponent";

		public RadialDamageWeaponComponent(FrostySdk.Ebx.RadialDamageWeaponComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

