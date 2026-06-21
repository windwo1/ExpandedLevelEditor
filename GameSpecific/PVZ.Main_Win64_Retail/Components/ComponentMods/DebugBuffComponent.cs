
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DebugBuffComponentData))]
	public class DebugBuffComponent : GameComponent, IEntityData<FrostySdk.Ebx.DebugBuffComponentData>
	{
		public new FrostySdk.Ebx.DebugBuffComponentData Data => data as FrostySdk.Ebx.DebugBuffComponentData;
		public override string DisplayName => "DebugBuffComponent";

		public DebugBuffComponent(FrostySdk.Ebx.DebugBuffComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

