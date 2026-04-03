
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LinkedEntityTrackData))]
	public class LinkedEntityTrack : EntityTrackBase, IEntityData<FrostySdk.Ebx.LinkedEntityTrackData>
	{
		public new FrostySdk.Ebx.LinkedEntityTrackData Data => data as FrostySdk.Ebx.LinkedEntityTrackData;
		public override string DisplayName => "LinkedEntityTrack";

		public LinkedEntityTrack(FrostySdk.Ebx.LinkedEntityTrackData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

