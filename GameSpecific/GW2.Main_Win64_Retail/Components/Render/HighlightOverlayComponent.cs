
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HighlightOverlayComponentData))]
	public class HighlightOverlayComponent : VisualEnvironmentComponent, IEntityData<FrostySdk.Ebx.HighlightOverlayComponentData>
	{
		public new FrostySdk.Ebx.HighlightOverlayComponentData Data => data as FrostySdk.Ebx.HighlightOverlayComponentData;
		public override string DisplayName => "HighlightOverlayComponent";

		public HighlightOverlayComponent(FrostySdk.Ebx.HighlightOverlayComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

