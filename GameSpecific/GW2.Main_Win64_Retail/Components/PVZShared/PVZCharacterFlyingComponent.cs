
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterFlyingComponentData))]
	public class PVZCharacterFlyingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterFlyingComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterFlyingComponentData Data => data as FrostySdk.Ebx.PVZCharacterFlyingComponentData;
		public override string DisplayName => "PVZCharacterFlyingComponent";

		public PVZCharacterFlyingComponent(FrostySdk.Ebx.PVZCharacterFlyingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

