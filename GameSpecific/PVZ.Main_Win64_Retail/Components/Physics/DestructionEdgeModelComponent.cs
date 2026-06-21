
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DestructionEdgeModelComponentData))]
	public class DestructionEdgeModelComponent : GameComponent, IEntityData<FrostySdk.Ebx.DestructionEdgeModelComponentData>
	{
		public new FrostySdk.Ebx.DestructionEdgeModelComponentData Data => data as FrostySdk.Ebx.DestructionEdgeModelComponentData;
		public override string DisplayName => "DestructionEdgeModelComponent";

		public DestructionEdgeModelComponent(FrostySdk.Ebx.DestructionEdgeModelComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

