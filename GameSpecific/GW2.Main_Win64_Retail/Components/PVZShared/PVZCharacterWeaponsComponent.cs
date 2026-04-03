
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterWeaponsComponentData))]
	public class PVZCharacterWeaponsComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterWeaponsComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterWeaponsComponentData Data => data as FrostySdk.Ebx.PVZCharacterWeaponsComponentData;
		public override string DisplayName => "PVZCharacterWeaponsComponent";

		public PVZCharacterWeaponsComponent(FrostySdk.Ebx.PVZCharacterWeaponsComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

