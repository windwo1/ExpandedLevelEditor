using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIIngameBoostsWidgetData))]
	public class UIIngameBoostsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIIngameBoostsWidgetData>
	{
		public new FrostySdk.Ebx.UIIngameBoostsWidgetData Data => data as FrostySdk.Ebx.UIIngameBoostsWidgetData;
		public override string DisplayName => "UIIngameBoostsWidget";

		public UIIngameBoostsWidget(FrostySdk.Ebx.UIIngameBoostsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

