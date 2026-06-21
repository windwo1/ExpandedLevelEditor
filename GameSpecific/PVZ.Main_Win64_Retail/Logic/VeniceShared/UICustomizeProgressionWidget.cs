using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICustomizeProgressionWidgetData))]
	public class UICustomizeProgressionWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UICustomizeProgressionWidgetData>
	{
		public new FrostySdk.Ebx.UICustomizeProgressionWidgetData Data => data as FrostySdk.Ebx.UICustomizeProgressionWidgetData;
		public override string DisplayName => "UICustomizeProgressionWidget";

		public UICustomizeProgressionWidget(FrostySdk.Ebx.UICustomizeProgressionWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

