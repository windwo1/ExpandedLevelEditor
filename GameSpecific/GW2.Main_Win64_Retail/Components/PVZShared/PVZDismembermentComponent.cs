
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZDismembermentComponentData))]
	public class PVZDismembermentComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZDismembermentComponentData>
	{
		public new FrostySdk.Ebx.PVZDismembermentComponentData Data => data as FrostySdk.Ebx.PVZDismembermentComponentData;
		public override string DisplayName => "PVZDismembermentComponent";

		public PVZDismembermentComponent(FrostySdk.Ebx.PVZDismembermentComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

