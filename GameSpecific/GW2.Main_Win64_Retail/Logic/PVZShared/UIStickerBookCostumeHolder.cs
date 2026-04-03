using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStickerBookCostumeHolderData))]
	public class UIStickerBookCostumeHolder : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIStickerBookCostumeHolderData>
	{
		public new FrostySdk.Ebx.UIStickerBookCostumeHolderData Data => data as FrostySdk.Ebx.UIStickerBookCostumeHolderData;
		public override string DisplayName => "UIStickerBookCostumeHolder";

		public UIStickerBookCostumeHolder(FrostySdk.Ebx.UIStickerBookCostumeHolderData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

