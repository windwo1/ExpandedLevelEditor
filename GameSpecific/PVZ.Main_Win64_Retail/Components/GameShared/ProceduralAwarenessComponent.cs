
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProceduralAwarenessComponentData))]
	public class ProceduralAwarenessComponent : GameComponent, IEntityData<FrostySdk.Ebx.ProceduralAwarenessComponentData>
	{
		public new FrostySdk.Ebx.ProceduralAwarenessComponentData Data => data as FrostySdk.Ebx.ProceduralAwarenessComponentData;
		public override string DisplayName => "ProceduralAwarenessComponent";

		public ProceduralAwarenessComponent(FrostySdk.Ebx.ProceduralAwarenessComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

