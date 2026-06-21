
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ObstacleComponentData))]
	public class ObstacleComponent : GameComponent, IEntityData<FrostySdk.Ebx.ObstacleComponentData>
	{
		public new FrostySdk.Ebx.ObstacleComponentData Data => data as FrostySdk.Ebx.ObstacleComponentData;
		public override string DisplayName => "ObstacleComponent";

		public ObstacleComponent(FrostySdk.Ebx.ObstacleComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

