
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsInputActivatorComponentData))]
	public class ModsInputActivatorComponent : GameComponent, IEntityData<FrostySdk.Ebx.ModsInputActivatorComponentData>
	{
		public new FrostySdk.Ebx.ModsInputActivatorComponentData Data => data as FrostySdk.Ebx.ModsInputActivatorComponentData;
		public override string DisplayName => "ModsInputActivatorComponent";

		public ModsInputActivatorComponent(FrostySdk.Ebx.ModsInputActivatorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

