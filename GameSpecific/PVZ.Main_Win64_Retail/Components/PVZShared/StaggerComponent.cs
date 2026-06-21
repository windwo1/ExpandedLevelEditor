
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.StaggerComponentData))]
	public class StaggerComponent : GameComponent, IEntityData<FrostySdk.Ebx.StaggerComponentData>
	{
		public new FrostySdk.Ebx.StaggerComponentData Data => data as FrostySdk.Ebx.StaggerComponentData;
		public override string DisplayName => "StaggerComponent";

		public StaggerComponent(FrostySdk.Ebx.StaggerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

