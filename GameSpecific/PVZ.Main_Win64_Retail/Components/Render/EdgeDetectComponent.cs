
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.EdgeDetectComponentData))]
	public class EdgeDetectComponent : VisualEnvironmentComponent, IEntityData<FrostySdk.Ebx.EdgeDetectComponentData>
	{
		public new FrostySdk.Ebx.EdgeDetectComponentData Data => data as FrostySdk.Ebx.EdgeDetectComponentData;
		public override string DisplayName => "EdgeDetectComponent";

		public EdgeDetectComponent(FrostySdk.Ebx.EdgeDetectComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

