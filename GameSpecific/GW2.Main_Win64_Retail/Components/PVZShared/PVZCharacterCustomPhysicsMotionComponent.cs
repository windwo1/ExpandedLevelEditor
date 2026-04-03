
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterCustomPhysicsMotionComponentData))]
	public class PVZCharacterCustomPhysicsMotionComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterCustomPhysicsMotionComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterCustomPhysicsMotionComponentData Data => data as FrostySdk.Ebx.PVZCharacterCustomPhysicsMotionComponentData;
		public override string DisplayName => "PVZCharacterCustomPhysicsMotionComponent";

		public PVZCharacterCustomPhysicsMotionComponent(FrostySdk.Ebx.PVZCharacterCustomPhysicsMotionComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

