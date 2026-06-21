
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BeamAnchorComponentData))]
	public class BeamAnchorComponent : GameComponent, IEntityData<FrostySdk.Ebx.BeamAnchorComponentData>
	{
		public new FrostySdk.Ebx.BeamAnchorComponentData Data => data as FrostySdk.Ebx.BeamAnchorComponentData;
		public override string DisplayName => "BeamAnchorComponent";

		public BeamAnchorComponent(FrostySdk.Ebx.BeamAnchorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

