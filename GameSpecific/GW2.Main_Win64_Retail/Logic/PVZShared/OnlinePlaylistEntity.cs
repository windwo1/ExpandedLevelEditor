using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.OnlinePlaylistEntityData))]
	public class OnlinePlaylistEntity : LogicEntity, IEntityData<FrostySdk.Ebx.OnlinePlaylistEntityData>
	{
		public new FrostySdk.Ebx.OnlinePlaylistEntityData Data => data as FrostySdk.Ebx.OnlinePlaylistEntityData;
		public override string DisplayName => "OnlinePlaylist";

		public OnlinePlaylistEntity(FrostySdk.Ebx.OnlinePlaylistEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

