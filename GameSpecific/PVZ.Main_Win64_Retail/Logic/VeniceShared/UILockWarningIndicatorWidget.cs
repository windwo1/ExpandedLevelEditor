using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILockWarningIndicatorWidgetData))]
	public class UILockWarningIndicatorWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UILockWarningIndicatorWidgetData>
	{
		public new FrostySdk.Ebx.UILockWarningIndicatorWidgetData Data => data as FrostySdk.Ebx.UILockWarningIndicatorWidgetData;
		public override string DisplayName => "UILockWarningIndicatorWidget";

		public UILockWarningIndicatorWidget(FrostySdk.Ebx.UILockWarningIndicatorWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

