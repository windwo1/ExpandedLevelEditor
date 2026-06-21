
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RoadieSprintComponentData))]
	public class RoadieSprintComponent : GameComponent, IEntityData<FrostySdk.Ebx.RoadieSprintComponentData>
	{
		public new FrostySdk.Ebx.RoadieSprintComponentData Data => data as FrostySdk.Ebx.RoadieSprintComponentData;
		public override string DisplayName => "RoadieSprintComponent";

		public RoadieSprintComponent(FrostySdk.Ebx.RoadieSprintComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

