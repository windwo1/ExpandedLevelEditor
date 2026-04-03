using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlayerGateEntityData))]
	public class PlayerGateEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PlayerGateEntityData>
	{
		public new FrostySdk.Ebx.PlayerGateEntityData Data => data as FrostySdk.Ebx.PlayerGateEntityData;
		public override string DisplayName => "PlayerGate";

		public PlayerGateEntity(FrostySdk.Ebx.PlayerGateEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

