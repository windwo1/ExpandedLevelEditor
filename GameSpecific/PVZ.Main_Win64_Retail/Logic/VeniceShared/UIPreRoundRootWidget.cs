using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPreRoundRootWidgetData))]
	public class UIPreRoundRootWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPreRoundRootWidgetData>
	{
		public new FrostySdk.Ebx.UIPreRoundRootWidgetData Data => data as FrostySdk.Ebx.UIPreRoundRootWidgetData;
		public override string DisplayName => "UIPreRoundRootWidget";

		public UIPreRoundRootWidget(FrostySdk.Ebx.UIPreRoundRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

