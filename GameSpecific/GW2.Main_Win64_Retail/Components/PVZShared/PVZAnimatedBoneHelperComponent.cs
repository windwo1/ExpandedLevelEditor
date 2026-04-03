
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAnimatedBoneHelperComponentData))]
	public class PVZAnimatedBoneHelperComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZAnimatedBoneHelperComponentData>
	{
		public new FrostySdk.Ebx.PVZAnimatedBoneHelperComponentData Data => data as FrostySdk.Ebx.PVZAnimatedBoneHelperComponentData;
		public override string DisplayName => "PVZAnimatedBoneHelperComponent";

		public PVZAnimatedBoneHelperComponent(FrostySdk.Ebx.PVZAnimatedBoneHelperComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

