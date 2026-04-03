using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlaylistInfoEntityData))]
	public class PlaylistInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PlaylistInfoEntityData>
	{
		public new FrostySdk.Ebx.PlaylistInfoEntityData Data => data as FrostySdk.Ebx.PlaylistInfoEntityData;
		public override string DisplayName => "PlaylistInfo";

		public PlaylistInfoEntity(FrostySdk.Ebx.PlaylistInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

