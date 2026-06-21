using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITextListWidgetData))]
	public class UITextListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITextListWidgetData>
	{
		public new FrostySdk.Ebx.UITextListWidgetData Data => data as FrostySdk.Ebx.UITextListWidgetData;
		public override string DisplayName => "UITextListWidget";

		public UITextListWidget(FrostySdk.Ebx.UITextListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

