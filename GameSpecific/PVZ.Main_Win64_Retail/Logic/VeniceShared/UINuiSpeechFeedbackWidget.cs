using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UINuiSpeechFeedbackWidgetData))]
	public class UINuiSpeechFeedbackWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UINuiSpeechFeedbackWidgetData>
	{
		public new FrostySdk.Ebx.UINuiSpeechFeedbackWidgetData Data => data as FrostySdk.Ebx.UINuiSpeechFeedbackWidgetData;
		public override string DisplayName => "UINuiSpeechFeedbackWidget";

		public UINuiSpeechFeedbackWidget(FrostySdk.Ebx.UINuiSpeechFeedbackWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

