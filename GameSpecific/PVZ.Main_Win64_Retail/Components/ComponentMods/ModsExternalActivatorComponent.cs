
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsExternalActivatorComponentData))]
	public class ModsExternalActivatorComponent : GameComponent, IEntityData<FrostySdk.Ebx.ModsExternalActivatorComponentData>
	{
		public new FrostySdk.Ebx.ModsExternalActivatorComponentData Data => data as FrostySdk.Ebx.ModsExternalActivatorComponentData;
		public override string DisplayName => "ModsExternalActivatorComponent";

		public ModsExternalActivatorComponent(FrostySdk.Ebx.ModsExternalActivatorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

