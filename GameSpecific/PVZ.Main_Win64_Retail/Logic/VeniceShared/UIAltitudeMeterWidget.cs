using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIAltitudeMeterWidgetData))]
	public class UIAltitudeMeterWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIAltitudeMeterWidgetData>
	{
		public new FrostySdk.Ebx.UIAltitudeMeterWidgetData Data => data as FrostySdk.Ebx.UIAltitudeMeterWidgetData;
		public override string DisplayName => "UIAltitudeMeterWidget";

		public UIAltitudeMeterWidget(FrostySdk.Ebx.UIAltitudeMeterWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

