
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffComponentData))]
	public class BuffComponent : GameComponent, IEntityData<FrostySdk.Ebx.BuffComponentData>
	{
		public new FrostySdk.Ebx.BuffComponentData Data => data as FrostySdk.Ebx.BuffComponentData;
		public override string DisplayName => "BuffComponent";

		public BuffComponent(FrostySdk.Ebx.BuffComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

