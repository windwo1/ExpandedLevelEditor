
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ObjectivesComponentData))]
	public class ObjectivesComponent : GameComponent, IEntityData<FrostySdk.Ebx.ObjectivesComponentData>
	{
		public new FrostySdk.Ebx.ObjectivesComponentData Data => data as FrostySdk.Ebx.ObjectivesComponentData;
		public override string DisplayName => "ObjectivesComponent";

		public ObjectivesComponent(FrostySdk.Ebx.ObjectivesComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

