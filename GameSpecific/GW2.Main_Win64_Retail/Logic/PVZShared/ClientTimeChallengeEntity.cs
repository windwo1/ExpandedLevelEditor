using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientTimeChallengeEntityData))]
	public class ClientTimeChallengeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientTimeChallengeEntityData>
	{
		public new FrostySdk.Ebx.ClientTimeChallengeEntityData Data => data as FrostySdk.Ebx.ClientTimeChallengeEntityData;
		public override string DisplayName => "ClientTimeChallenge";

		public ClientTimeChallengeEntity(FrostySdk.Ebx.ClientTimeChallengeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

