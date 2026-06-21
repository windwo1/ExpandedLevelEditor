
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RootingComponentData))]
	public class RootingComponent : GameComponent, IEntityData<FrostySdk.Ebx.RootingComponentData>
	{
		public new FrostySdk.Ebx.RootingComponentData Data => data as FrostySdk.Ebx.RootingComponentData;
		public override string DisplayName => "RootingComponent";

		public RootingComponent(FrostySdk.Ebx.RootingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

