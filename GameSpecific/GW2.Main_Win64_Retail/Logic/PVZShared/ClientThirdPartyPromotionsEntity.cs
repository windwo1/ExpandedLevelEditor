using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientThirdPartyPromotionsEntityData))]
	public class ClientThirdPartyPromotionsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientThirdPartyPromotionsEntityData>
	{
		public new FrostySdk.Ebx.ClientThirdPartyPromotionsEntityData Data => data as FrostySdk.Ebx.ClientThirdPartyPromotionsEntityData;
		public override string DisplayName => "ClientThirdPartyPromotions";

		public ClientThirdPartyPromotionsEntity(FrostySdk.Ebx.ClientThirdPartyPromotionsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

