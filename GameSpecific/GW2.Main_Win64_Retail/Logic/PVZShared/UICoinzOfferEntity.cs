using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICoinzOfferEntityData))]
	public class UICoinzOfferEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICoinzOfferEntityData>
	{
		public new FrostySdk.Ebx.UICoinzOfferEntityData Data => data as FrostySdk.Ebx.UICoinzOfferEntityData;
		public override string DisplayName => "UICoinzOffer";

		public UICoinzOfferEntity(FrostySdk.Ebx.UICoinzOfferEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

