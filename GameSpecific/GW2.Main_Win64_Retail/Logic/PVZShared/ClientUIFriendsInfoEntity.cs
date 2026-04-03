using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientUIFriendsInfoEntityData))]
	public class ClientUIFriendsInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientUIFriendsInfoEntityData>
	{
		public new FrostySdk.Ebx.ClientUIFriendsInfoEntityData Data => data as FrostySdk.Ebx.ClientUIFriendsInfoEntityData;
		public override string DisplayName => "ClientUIFriendsInfo";

		public ClientUIFriendsInfoEntity(FrostySdk.Ebx.ClientUIFriendsInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

