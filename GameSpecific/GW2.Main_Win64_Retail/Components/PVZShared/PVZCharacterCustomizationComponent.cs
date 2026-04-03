
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterCustomizationComponentData))]
	public class PVZCharacterCustomizationComponent : CharacterCustomizationComponent, IEntityData<FrostySdk.Ebx.PVZCharacterCustomizationComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterCustomizationComponentData Data => data as FrostySdk.Ebx.PVZCharacterCustomizationComponentData;
		public override string DisplayName => "PVZCharacterCustomizationComponent";

		public PVZCharacterCustomizationComponent(FrostySdk.Ebx.PVZCharacterCustomizationComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

