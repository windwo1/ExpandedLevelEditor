
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamComponentData))]
	public class TeamComponent : GameComponent, IEntityData<FrostySdk.Ebx.TeamComponentData>
	{
		public new FrostySdk.Ebx.TeamComponentData Data => data as FrostySdk.Ebx.TeamComponentData;
		public override string DisplayName => "TeamComponent";

		public TeamComponent(FrostySdk.Ebx.TeamComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

