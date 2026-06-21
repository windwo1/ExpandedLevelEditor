
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsActivatorComponentData))]
	public class ModsActivatorComponent : GameComponent, IEntityData<FrostySdk.Ebx.ModsActivatorComponentData>
	{
		public new FrostySdk.Ebx.ModsActivatorComponentData Data => data as FrostySdk.Ebx.ModsActivatorComponentData;
		public override string DisplayName => "ModsActivatorComponent";

		public ModsActivatorComponent(FrostySdk.Ebx.ModsActivatorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

