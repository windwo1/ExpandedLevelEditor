using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStickerBookCostumeWidgetData))]
	public class UIStickerBookCostumeWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIStickerBookCostumeWidgetData>
	{
		public new FrostySdk.Ebx.UIStickerBookCostumeWidgetData Data => data as FrostySdk.Ebx.UIStickerBookCostumeWidgetData;
		public override string DisplayName => "UIStickerBookCostumeWidget";

		public UIStickerBookCostumeWidget(FrostySdk.Ebx.UIStickerBookCostumeWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

