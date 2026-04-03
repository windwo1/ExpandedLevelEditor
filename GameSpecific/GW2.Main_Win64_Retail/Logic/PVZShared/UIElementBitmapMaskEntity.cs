using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementBitmapMaskEntityData))]
	public class UIElementBitmapMaskEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementBitmapMaskEntityData>
	{
		public new FrostySdk.Ebx.UIElementBitmapMaskEntityData Data => data as FrostySdk.Ebx.UIElementBitmapMaskEntityData;
		public override string DisplayName => "UIElementBitmapMask";

		public UIElementBitmapMaskEntity(FrostySdk.Ebx.UIElementBitmapMaskEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

