
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterAntAnimatableComponentData))]
	public class PVZCharacterAntAnimatableComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterAntAnimatableComponentData Data => data as FrostySdk.Ebx.PVZCharacterAntAnimatableComponentData;
		public override string DisplayName => "PVZCharacterAntAnimatableComponent";

		public PVZCharacterAntAnimatableComponent(FrostySdk.Ebx.PVZCharacterAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

