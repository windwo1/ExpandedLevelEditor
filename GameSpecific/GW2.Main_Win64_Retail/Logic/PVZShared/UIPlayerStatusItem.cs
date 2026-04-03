using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPlayerStatusItemData))]
	public class UIPlayerStatusItem : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPlayerStatusItemData>
	{
		public new FrostySdk.Ebx.UIPlayerStatusItemData Data => data as FrostySdk.Ebx.UIPlayerStatusItemData;
		public override string DisplayName => "UIPlayerStatusItem";

		public UIPlayerStatusItem(FrostySdk.Ebx.UIPlayerStatusItemData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

