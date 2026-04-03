using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientPlayerManagerEntityData))]
	public class ClientPlayerManagerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientPlayerManagerEntityData>
	{
		public new FrostySdk.Ebx.ClientPlayerManagerEntityData Data => data as FrostySdk.Ebx.ClientPlayerManagerEntityData;
		public override string DisplayName => "ClientPlayerManager";

		public ClientPlayerManagerEntity(FrostySdk.Ebx.ClientPlayerManagerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

