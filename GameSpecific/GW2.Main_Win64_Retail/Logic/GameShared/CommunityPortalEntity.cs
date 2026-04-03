using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CommunityPortalEntityData))]
	public class CommunityPortalEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CommunityPortalEntityData>
	{
		public new FrostySdk.Ebx.CommunityPortalEntityData Data => data as FrostySdk.Ebx.CommunityPortalEntityData;
		public override string DisplayName => "CommunityPortal";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CommunityPortalEntity(FrostySdk.Ebx.CommunityPortalEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

