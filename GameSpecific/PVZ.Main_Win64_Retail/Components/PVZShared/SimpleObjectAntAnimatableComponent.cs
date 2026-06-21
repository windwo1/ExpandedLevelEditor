
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SimpleObjectAntAnimatableComponentData))]
	public class SimpleObjectAntAnimatableComponent : LodAntAnimatableComponent, IEntityData<FrostySdk.Ebx.SimpleObjectAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.SimpleObjectAntAnimatableComponentData Data => data as FrostySdk.Ebx.SimpleObjectAntAnimatableComponentData;
		public override string DisplayName => "SimpleObjectAntAnimatableComponent";

		public SimpleObjectAntAnimatableComponent(FrostySdk.Ebx.SimpleObjectAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

