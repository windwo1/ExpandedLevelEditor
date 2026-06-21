using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBasicLoadingIndicatorWidgetData))]
	public class UIBasicLoadingIndicatorWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBasicLoadingIndicatorWidgetData>
	{
		public new FrostySdk.Ebx.UIBasicLoadingIndicatorWidgetData Data => data as FrostySdk.Ebx.UIBasicLoadingIndicatorWidgetData;
		public override string DisplayName => "UIBasicLoadingIndicatorWidget";

		public UIBasicLoadingIndicatorWidget(FrostySdk.Ebx.UIBasicLoadingIndicatorWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

