
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CollectableItemComponentData))]
	public class CollectableItemComponent : GameComponent, IEntityData<FrostySdk.Ebx.CollectableItemComponentData>
	{
		public new FrostySdk.Ebx.CollectableItemComponentData Data => data as FrostySdk.Ebx.CollectableItemComponentData;
		public override string DisplayName => "CollectableItemComponent";

		public CollectableItemComponent(FrostySdk.Ebx.CollectableItemComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

