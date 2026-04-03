
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterWeaponSwitchingComponentData))]
	public class PVZCharacterWeaponSwitchingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterWeaponSwitchingComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterWeaponSwitchingComponentData Data => data as FrostySdk.Ebx.PVZCharacterWeaponSwitchingComponentData;
		public override string DisplayName => "PVZCharacterWeaponSwitchingComponent";

		public PVZCharacterWeaponSwitchingComponent(FrostySdk.Ebx.PVZCharacterWeaponSwitchingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

