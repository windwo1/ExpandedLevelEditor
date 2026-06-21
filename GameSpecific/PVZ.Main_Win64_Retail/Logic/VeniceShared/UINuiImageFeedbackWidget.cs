using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UINuiImageFeedbackWidgetData))]
	public class UINuiImageFeedbackWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UINuiImageFeedbackWidgetData>
	{
		public new FrostySdk.Ebx.UINuiImageFeedbackWidgetData Data => data as FrostySdk.Ebx.UINuiImageFeedbackWidgetData;
		public override string DisplayName => "UINuiImageFeedbackWidget";

		public UINuiImageFeedbackWidget(FrostySdk.Ebx.UINuiImageFeedbackWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

