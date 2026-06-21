using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMainMenuTopStoryWidgetData))]
	public class UIMainMenuTopStoryWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMainMenuTopStoryWidgetData>
	{
		public new FrostySdk.Ebx.UIMainMenuTopStoryWidgetData Data => data as FrostySdk.Ebx.UIMainMenuTopStoryWidgetData;
		public override string DisplayName => "UIMainMenuTopStoryWidget";

		public UIMainMenuTopStoryWidget(FrostySdk.Ebx.UIMainMenuTopStoryWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

