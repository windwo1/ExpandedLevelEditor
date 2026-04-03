using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.OnlinePlaylistControlEntityData))]
	public class OnlinePlaylistControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.OnlinePlaylistControlEntityData>
	{
		public new FrostySdk.Ebx.OnlinePlaylistControlEntityData Data => data as FrostySdk.Ebx.OnlinePlaylistControlEntityData;
		public override string DisplayName => "OnlinePlaylistControl";

		public OnlinePlaylistControlEntity(FrostySdk.Ebx.OnlinePlaylistControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

