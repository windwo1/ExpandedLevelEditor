using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILoadingProgressWidgetData))]
	public class UILoadingProgressWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UILoadingProgressWidgetData>
	{
		public new FrostySdk.Ebx.UILoadingProgressWidgetData Data => data as FrostySdk.Ebx.UILoadingProgressWidgetData;
		public override string DisplayName => "UILoadingProgressWidget";

		public UILoadingProgressWidget(FrostySdk.Ebx.UILoadingProgressWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

