using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIOptionsKeybindingsWidgetData))]
	public class UIOptionsKeybindingsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIOptionsKeybindingsWidgetData>
	{
		public new FrostySdk.Ebx.UIOptionsKeybindingsWidgetData Data => data as FrostySdk.Ebx.UIOptionsKeybindingsWidgetData;
		public override string DisplayName => "UIOptionsKeybindingsWidget";

		public UIOptionsKeybindingsWidget(FrostySdk.Ebx.UIOptionsKeybindingsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

