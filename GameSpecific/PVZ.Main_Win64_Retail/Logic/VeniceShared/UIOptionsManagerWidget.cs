using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIOptionsManagerWidgetData))]
	public class UIOptionsManagerWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIOptionsManagerWidgetData>
	{
		public new FrostySdk.Ebx.UIOptionsManagerWidgetData Data => data as FrostySdk.Ebx.UIOptionsManagerWidgetData;
		public override string DisplayName => "UIOptionsManagerWidget";

		public UIOptionsManagerWidget(FrostySdk.Ebx.UIOptionsManagerWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

