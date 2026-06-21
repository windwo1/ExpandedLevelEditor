
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsJumpComponentData))]
	public class ModsJumpComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsJumpComponentData>
	{
		public new FrostySdk.Ebx.ModsJumpComponentData Data => data as FrostySdk.Ebx.ModsJumpComponentData;
		public override string DisplayName => "ModsJumpComponent";

		public ModsJumpComponent(FrostySdk.Ebx.ModsJumpComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

