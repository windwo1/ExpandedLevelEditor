using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientBlackMarketEntityData))]
	public class ClientBlackMarketEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientBlackMarketEntityData>
	{
		public new FrostySdk.Ebx.ClientBlackMarketEntityData Data => data as FrostySdk.Ebx.ClientBlackMarketEntityData;
		public override string DisplayName => "ClientBlackMarket";

		public ClientBlackMarketEntity(FrostySdk.Ebx.ClientBlackMarketEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

