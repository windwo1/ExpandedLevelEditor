using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIServerBrowserWidgetData))]
	public class UIServerBrowserWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIServerBrowserWidgetData>
	{
		public new FrostySdk.Ebx.UIServerBrowserWidgetData Data => data as FrostySdk.Ebx.UIServerBrowserWidgetData;
		public override string DisplayName => "UIServerBrowserWidget";

		public UIServerBrowserWidget(FrostySdk.Ebx.UIServerBrowserWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

