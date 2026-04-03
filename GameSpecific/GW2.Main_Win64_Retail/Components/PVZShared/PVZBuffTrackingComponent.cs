
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZBuffTrackingComponentData))]
	public class PVZBuffTrackingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZBuffTrackingComponentData>
	{
		public new FrostySdk.Ebx.PVZBuffTrackingComponentData Data => data as FrostySdk.Ebx.PVZBuffTrackingComponentData;
		public override string DisplayName => "PVZBuffTrackingComponent";

		public PVZBuffTrackingComponent(FrostySdk.Ebx.PVZBuffTrackingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

