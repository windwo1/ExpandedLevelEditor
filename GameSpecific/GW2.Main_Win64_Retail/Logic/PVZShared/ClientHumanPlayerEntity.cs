using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientHumanPlayerEntityData))]
	public class ClientHumanPlayerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientHumanPlayerEntityData>
	{
		public new FrostySdk.Ebx.ClientHumanPlayerEntityData Data => data as FrostySdk.Ebx.ClientHumanPlayerEntityData;
		public override string DisplayName => "ClientHumanPlayer";

		public ClientHumanPlayerEntity(FrostySdk.Ebx.ClientHumanPlayerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

