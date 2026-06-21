using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AntTrackData))]
	public class AntTrack : CustomSequenceTrack, IEntityData<FrostySdk.Ebx.AntTrackData>
	{
		public new FrostySdk.Ebx.AntTrackData Data => data as FrostySdk.Ebx.AntTrackData;
		public override string DisplayName => "AntTrack";

		public AntTrack(FrostySdk.Ebx.AntTrackData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

