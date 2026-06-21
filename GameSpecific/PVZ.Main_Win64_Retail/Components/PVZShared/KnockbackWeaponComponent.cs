
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.KnockbackWeaponComponentData))]
	public class KnockbackWeaponComponent : GameComponent, IEntityData<FrostySdk.Ebx.KnockbackWeaponComponentData>
	{
		public new FrostySdk.Ebx.KnockbackWeaponComponentData Data => data as FrostySdk.Ebx.KnockbackWeaponComponentData;
		public override string DisplayName => "KnockbackWeaponComponent";

		public KnockbackWeaponComponent(FrostySdk.Ebx.KnockbackWeaponComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

