using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ServerCoopCheckpointEntityData))]
	public class ServerCoopCheckpointEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ServerCoopCheckpointEntityData>
	{
		public new FrostySdk.Ebx.ServerCoopCheckpointEntityData Data => data as FrostySdk.Ebx.ServerCoopCheckpointEntityData;
		public override string DisplayName => "ServerCoopCheckpoint";

		public ServerCoopCheckpointEntity(FrostySdk.Ebx.ServerCoopCheckpointEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

