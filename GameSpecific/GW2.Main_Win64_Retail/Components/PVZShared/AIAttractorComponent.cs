
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIAttractorComponentData))]
	public class AIAttractorComponent : GameComponent, IEntityData<FrostySdk.Ebx.AIAttractorComponentData>
	{
		public new FrostySdk.Ebx.AIAttractorComponentData Data => data as FrostySdk.Ebx.AIAttractorComponentData;
		public override string DisplayName => "AIAttractorComponent";

		public AIAttractorComponent(FrostySdk.Ebx.AIAttractorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

