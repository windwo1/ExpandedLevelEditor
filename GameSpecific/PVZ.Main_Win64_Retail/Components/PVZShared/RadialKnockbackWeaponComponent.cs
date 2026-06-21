
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RadialKnockbackWeaponComponentData))]
	public class RadialKnockbackWeaponComponent : RadialDamageWeaponComponent, IEntityData<FrostySdk.Ebx.RadialKnockbackWeaponComponentData>
	{
		public new FrostySdk.Ebx.RadialKnockbackWeaponComponentData Data => data as FrostySdk.Ebx.RadialKnockbackWeaponComponentData;
		public override string DisplayName => "RadialKnockbackWeaponComponent";

		public RadialKnockbackWeaponComponent(FrostySdk.Ebx.RadialKnockbackWeaponComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

