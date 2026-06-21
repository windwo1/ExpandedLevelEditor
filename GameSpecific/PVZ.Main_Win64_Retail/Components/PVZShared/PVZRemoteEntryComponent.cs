
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZRemoteEntryComponentData))]
	public class PVZRemoteEntryComponent : RemoteEntryComponent, IEntityData<FrostySdk.Ebx.PVZRemoteEntryComponentData>
	{
		public new FrostySdk.Ebx.PVZRemoteEntryComponentData Data => data as FrostySdk.Ebx.PVZRemoteEntryComponentData;
		public override string DisplayName => "PVZRemoteEntryComponent";

		public PVZRemoteEntryComponent(FrostySdk.Ebx.PVZRemoteEntryComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

