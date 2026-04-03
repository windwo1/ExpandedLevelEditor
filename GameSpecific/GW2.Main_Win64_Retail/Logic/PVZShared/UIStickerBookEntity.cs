using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStickerBookEntityData))]
	public class UIStickerBookEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIStickerBookEntityData>
	{
		public new FrostySdk.Ebx.UIStickerBookEntityData Data => data as FrostySdk.Ebx.UIStickerBookEntityData;
		public override string DisplayName => "UIStickerBook";

		public UIStickerBookEntity(FrostySdk.Ebx.UIStickerBookEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

