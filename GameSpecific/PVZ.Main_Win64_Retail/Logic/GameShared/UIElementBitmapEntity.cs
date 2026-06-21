using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementBitmapEntityData))]
	public class UIElementBitmapEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementBitmapEntityData>
	{
		public new FrostySdk.Ebx.UIElementBitmapEntityData Data => data as FrostySdk.Ebx.UIElementBitmapEntityData;
		public override string DisplayName => "UIElementBitmap";

		public UIElementBitmapEntity(FrostySdk.Ebx.UIElementBitmapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

