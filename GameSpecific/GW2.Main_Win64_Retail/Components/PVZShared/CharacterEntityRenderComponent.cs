
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CharacterEntityRenderComponentData))]
	public class CharacterEntityRenderComponent : GameComponent, IEntityData<FrostySdk.Ebx.CharacterEntityRenderComponentData>
	{
		public new FrostySdk.Ebx.CharacterEntityRenderComponentData Data => data as FrostySdk.Ebx.CharacterEntityRenderComponentData;
		public override string DisplayName => "CharacterEntityRenderComponent";

		public CharacterEntityRenderComponent(FrostySdk.Ebx.CharacterEntityRenderComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

