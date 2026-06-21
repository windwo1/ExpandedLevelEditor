
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WarpingComponentData))]
	public class WarpingComponent : GameComponent, IEntityData<FrostySdk.Ebx.WarpingComponentData>
	{
		public new FrostySdk.Ebx.WarpingComponentData Data => data as FrostySdk.Ebx.WarpingComponentData;
		public override string DisplayName => "WarpingComponent";

		public WarpingComponent(FrostySdk.Ebx.WarpingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

