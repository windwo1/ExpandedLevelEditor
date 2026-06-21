using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIProgressionBarWidgetData))]
	public class UIProgressionBarWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIProgressionBarWidgetData>
	{
		public new FrostySdk.Ebx.UIProgressionBarWidgetData Data => data as FrostySdk.Ebx.UIProgressionBarWidgetData;
		public override string DisplayName => "UIProgressionBarWidget";

		public UIProgressionBarWidget(FrostySdk.Ebx.UIProgressionBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

