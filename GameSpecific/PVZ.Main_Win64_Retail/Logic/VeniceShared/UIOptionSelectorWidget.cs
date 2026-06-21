using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIOptionSelectorWidgetData))]
	public class UIOptionSelectorWidget : UIPageChildWidget, IEntityData<FrostySdk.Ebx.UIOptionSelectorWidgetData>
	{
		public new FrostySdk.Ebx.UIOptionSelectorWidgetData Data => data as FrostySdk.Ebx.UIOptionSelectorWidgetData;
		public override string DisplayName => "UIOptionSelectorWidget";

		public UIOptionSelectorWidget(FrostySdk.Ebx.UIOptionSelectorWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

