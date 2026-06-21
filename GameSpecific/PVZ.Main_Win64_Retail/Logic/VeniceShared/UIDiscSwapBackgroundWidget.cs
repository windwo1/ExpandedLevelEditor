using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDiscSwapBackgroundWidgetData))]
	public class UIDiscSwapBackgroundWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIDiscSwapBackgroundWidgetData>
	{
		public new FrostySdk.Ebx.UIDiscSwapBackgroundWidgetData Data => data as FrostySdk.Ebx.UIDiscSwapBackgroundWidgetData;
		public override string DisplayName => "UIDiscSwapBackgroundWidget";

		public UIDiscSwapBackgroundWidget(FrostySdk.Ebx.UIDiscSwapBackgroundWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

