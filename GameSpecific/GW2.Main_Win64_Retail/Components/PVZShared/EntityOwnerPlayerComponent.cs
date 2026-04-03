
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.EntityOwnerPlayerComponentData))]
	public class EntityOwnerPlayerComponent : GameComponent, IEntityData<FrostySdk.Ebx.EntityOwnerPlayerComponentData>
	{
		public new FrostySdk.Ebx.EntityOwnerPlayerComponentData Data => data as FrostySdk.Ebx.EntityOwnerPlayerComponentData;
		public override string DisplayName => "EntityOwnerPlayerComponent";

		public EntityOwnerPlayerComponent(FrostySdk.Ebx.EntityOwnerPlayerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

