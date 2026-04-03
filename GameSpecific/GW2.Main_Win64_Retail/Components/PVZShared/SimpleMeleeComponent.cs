
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SimpleMeleeComponentData))]
	public class SimpleMeleeComponent : Component, IEntityData<FrostySdk.Ebx.SimpleMeleeComponentData>
	{
		public new FrostySdk.Ebx.SimpleMeleeComponentData Data => data as FrostySdk.Ebx.SimpleMeleeComponentData;
		public override string DisplayName => "SimpleMeleeComponent";

		public SimpleMeleeComponent(FrostySdk.Ebx.SimpleMeleeComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

