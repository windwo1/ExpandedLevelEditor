using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGenericWidgetData))]
	public class UIGenericWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIGenericWidgetData>
	{
		public new FrostySdk.Ebx.UIGenericWidgetData Data => data as FrostySdk.Ebx.UIGenericWidgetData;
		public override string DisplayName => "UIGenericWidget";

		public UIGenericWidget(FrostySdk.Ebx.UIGenericWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

