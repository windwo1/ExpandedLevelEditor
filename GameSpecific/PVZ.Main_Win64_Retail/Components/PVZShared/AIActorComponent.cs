
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIActorComponentData))]
	public class AIActorComponent : GameComponent, IEntityData<FrostySdk.Ebx.AIActorComponentData>
	{
		public new FrostySdk.Ebx.AIActorComponentData Data => data as FrostySdk.Ebx.AIActorComponentData;
		public override string DisplayName => "AIActorComponent";

		public AIActorComponent(FrostySdk.Ebx.AIActorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

