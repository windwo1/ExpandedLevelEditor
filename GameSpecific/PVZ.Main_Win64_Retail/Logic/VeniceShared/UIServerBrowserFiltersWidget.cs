using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIServerBrowserFiltersWidgetData))]
	public class UIServerBrowserFiltersWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIServerBrowserFiltersWidgetData>
	{
		public new FrostySdk.Ebx.UIServerBrowserFiltersWidgetData Data => data as FrostySdk.Ebx.UIServerBrowserFiltersWidgetData;
		public override string DisplayName => "UIServerBrowserFiltersWidget";

		public UIServerBrowserFiltersWidget(FrostySdk.Ebx.UIServerBrowserFiltersWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

