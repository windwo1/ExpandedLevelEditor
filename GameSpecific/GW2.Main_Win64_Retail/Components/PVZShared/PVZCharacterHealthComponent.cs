
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterHealthComponentData))]
	public class PVZCharacterHealthComponent : CharacterHealthComponent, IEntityData<FrostySdk.Ebx.PVZCharacterHealthComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterHealthComponentData Data => data as FrostySdk.Ebx.PVZCharacterHealthComponentData;
		public override string DisplayName => "PVZCharacterHealthComponent";

		public PVZCharacterHealthComponent(FrostySdk.Ebx.PVZCharacterHealthComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

