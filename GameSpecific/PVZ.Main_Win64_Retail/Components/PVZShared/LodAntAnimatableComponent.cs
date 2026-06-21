
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LodAntAnimatableComponentData))]
	public class LodAntAnimatableComponent : AntAnimatableComponent, IEntityData<FrostySdk.Ebx.LodAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.LodAntAnimatableComponentData Data => data as FrostySdk.Ebx.LodAntAnimatableComponentData;
		public override string DisplayName => "LodAntAnimatableComponent";

		public LodAntAnimatableComponent(FrostySdk.Ebx.LodAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

