using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIVoiceCommandsListWidgetData))]
	public class UIVoiceCommandsListWidget : UITextEntryListWidget, IEntityData<FrostySdk.Ebx.UIVoiceCommandsListWidgetData>
	{
		public new FrostySdk.Ebx.UIVoiceCommandsListWidgetData Data => data as FrostySdk.Ebx.UIVoiceCommandsListWidgetData;
		public override string DisplayName => "UIVoiceCommandsListWidget";

		public UIVoiceCommandsListWidget(FrostySdk.Ebx.UIVoiceCommandsListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

