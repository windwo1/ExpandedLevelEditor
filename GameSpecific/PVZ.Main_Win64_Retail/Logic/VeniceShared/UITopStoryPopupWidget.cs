using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITopStoryPopupWidgetData))]
	public class UITopStoryPopupWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITopStoryPopupWidgetData>
	{
		public new FrostySdk.Ebx.UITopStoryPopupWidgetData Data => data as FrostySdk.Ebx.UITopStoryPopupWidgetData;
		public override string DisplayName => "UITopStoryPopupWidget";

		public UITopStoryPopupWidget(FrostySdk.Ebx.UITopStoryPopupWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

