
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AnimatedPointCloudComponentData))]
	public class AnimatedPointCloudComponent : GameComponent, IEntityData<FrostySdk.Ebx.AnimatedPointCloudComponentData>
	{
		public new FrostySdk.Ebx.AnimatedPointCloudComponentData Data => data as FrostySdk.Ebx.AnimatedPointCloudComponentData;
		public override string DisplayName => "AnimatedPointCloudComponent";

		public AnimatedPointCloudComponent(FrostySdk.Ebx.AnimatedPointCloudComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

