
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIAwarenessComponentData))]
	public class AIAwarenessComponent : GameComponent, IEntityData<FrostySdk.Ebx.AIAwarenessComponentData>
	{
		public new FrostySdk.Ebx.AIAwarenessComponentData Data => data as FrostySdk.Ebx.AIAwarenessComponentData;
		public override string DisplayName => "AIAwarenessComponent";

		public AIAwarenessComponent(FrostySdk.Ebx.AIAwarenessComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

