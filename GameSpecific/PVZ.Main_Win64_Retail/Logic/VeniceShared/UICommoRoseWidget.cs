using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICommoRoseWidgetData))]
	public class UICommoRoseWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UICommoRoseWidgetData>
	{
		public new FrostySdk.Ebx.UICommoRoseWidgetData Data => data as FrostySdk.Ebx.UICommoRoseWidgetData;
		public override string DisplayName => "UICommoRoseWidget";

		public UICommoRoseWidget(FrostySdk.Ebx.UICommoRoseWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

