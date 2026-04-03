using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CommunityChallengeEntityData))]
	public class CommunityChallengeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CommunityChallengeEntityData>
	{
		public new FrostySdk.Ebx.CommunityChallengeEntityData Data => data as FrostySdk.Ebx.CommunityChallengeEntityData;
		public override string DisplayName => "CommunityChallenge";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CommunityChallengeEntity(FrostySdk.Ebx.CommunityChallengeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

