
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AnimatedDestructionComponentData))]
	public class AnimatedDestructionComponent : AntAnimatableComponent, IEntityData<FrostySdk.Ebx.AnimatedDestructionComponentData>
	{
		public new FrostySdk.Ebx.AnimatedDestructionComponentData Data => data as FrostySdk.Ebx.AnimatedDestructionComponentData;
		public override string DisplayName => "AnimatedDestructionComponent";

		public AnimatedDestructionComponent(FrostySdk.Ebx.AnimatedDestructionComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

