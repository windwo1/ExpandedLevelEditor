using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDebugWidgetData))]
	public class UIDebugWidget : UIWidgetEntity, IEntityData<FrostySdk.Ebx.UIDebugWidgetData>
	{
		public new FrostySdk.Ebx.UIDebugWidgetData Data => data as FrostySdk.Ebx.UIDebugWidgetData;
		public override string DisplayName => "UIDebugWidget";

		public UIDebugWidget(FrostySdk.Ebx.UIDebugWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

