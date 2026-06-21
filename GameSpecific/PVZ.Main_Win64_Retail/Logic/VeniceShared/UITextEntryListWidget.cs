using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITextEntryListWidgetData))]
	public class UITextEntryListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITextEntryListWidgetData>
	{
		public new FrostySdk.Ebx.UITextEntryListWidgetData Data => data as FrostySdk.Ebx.UITextEntryListWidgetData;
		public override string DisplayName => "UITextEntryListWidget";

		public UITextEntryListWidget(FrostySdk.Ebx.UITextEntryListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

