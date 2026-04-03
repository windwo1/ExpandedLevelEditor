
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAntBindingComponentData))]
	public class PVZAntBindingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZAntBindingComponentData>
	{
		public new FrostySdk.Ebx.PVZAntBindingComponentData Data => data as FrostySdk.Ebx.PVZAntBindingComponentData;
		public override string DisplayName => "PVZAntBindingComponent";

		public PVZAntBindingComponent(FrostySdk.Ebx.PVZAntBindingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

