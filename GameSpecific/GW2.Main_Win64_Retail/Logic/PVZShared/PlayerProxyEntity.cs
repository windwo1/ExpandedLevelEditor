using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlayerProxyEntityData))]
	public class PlayerProxyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PlayerProxyEntityData>
	{
		public new FrostySdk.Ebx.PlayerProxyEntityData Data => data as FrostySdk.Ebx.PlayerProxyEntityData;
		public override string DisplayName => "PlayerProxy";

		public PlayerProxyEntity(FrostySdk.Ebx.PlayerProxyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

