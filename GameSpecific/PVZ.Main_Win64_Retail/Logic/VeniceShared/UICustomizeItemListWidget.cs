using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICustomizeItemListWidgetData))]
	public class UICustomizeItemListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UICustomizeItemListWidgetData>
	{
		public new FrostySdk.Ebx.UICustomizeItemListWidgetData Data => data as FrostySdk.Ebx.UICustomizeItemListWidgetData;
		public override string DisplayName => "UICustomizeItemListWidget";

		public UICustomizeItemListWidget(FrostySdk.Ebx.UICustomizeItemListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

