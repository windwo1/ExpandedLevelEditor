
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AntAnimatableComponentData))]
	public class AntAnimatableComponent : GameComponent, IEntityData<FrostySdk.Ebx.AntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.AntAnimatableComponentData Data => data as FrostySdk.Ebx.AntAnimatableComponentData;
		public override string DisplayName => "AntAnimatableComponent";

		public AntAnimatableComponent(FrostySdk.Ebx.AntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

