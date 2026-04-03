
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterPhysicsComponentData))]
	public class PVZCharacterPhysicsComponent : CharacterMasterPhysicsComponent, IEntityData<FrostySdk.Ebx.PVZCharacterPhysicsComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterPhysicsComponentData Data => data as FrostySdk.Ebx.PVZCharacterPhysicsComponentData;
		public override string DisplayName => "PVZCharacterPhysicsComponent";

		public PVZCharacterPhysicsComponent(FrostySdk.Ebx.PVZCharacterPhysicsComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

