using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPageChildWidgetData))]
	public class UIPageChildWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPageChildWidgetData>
	{
		public new FrostySdk.Ebx.UIPageChildWidgetData Data => data as FrostySdk.Ebx.UIPageChildWidgetData;
		public override string DisplayName => "UIPageChildWidget";

		public UIPageChildWidget(FrostySdk.Ebx.UIPageChildWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

