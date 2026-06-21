
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WeaponCharacterProxyComponentData))]
	public class WeaponCharacterProxyComponent : GameComponent, IEntityData<FrostySdk.Ebx.WeaponCharacterProxyComponentData>
	{
		public new FrostySdk.Ebx.WeaponCharacterProxyComponentData Data => data as FrostySdk.Ebx.WeaponCharacterProxyComponentData;
		public override string DisplayName => "WeaponCharacterProxyComponent";

		public WeaponCharacterProxyComponent(FrostySdk.Ebx.WeaponCharacterProxyComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

