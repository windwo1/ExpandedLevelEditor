using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIOptionsListWidgetData))]
	public class UIOptionsListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIOptionsListWidgetData>
	{
		public new FrostySdk.Ebx.UIOptionsListWidgetData Data => data as FrostySdk.Ebx.UIOptionsListWidgetData;
		public override string DisplayName => "UIOptionsListWidget";

		public UIOptionsListWidget(FrostySdk.Ebx.UIOptionsListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

