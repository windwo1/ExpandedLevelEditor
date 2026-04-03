
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SpecialModeWeaponComponentData))]
	public class SpecialModeWeaponComponent : GameComponent, IEntityData<FrostySdk.Ebx.SpecialModeWeaponComponentData>
	{
		public new FrostySdk.Ebx.SpecialModeWeaponComponentData Data => data as FrostySdk.Ebx.SpecialModeWeaponComponentData;
		public override string DisplayName => "SpecialModeWeaponComponent";

		public SpecialModeWeaponComponent(FrostySdk.Ebx.SpecialModeWeaponComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

