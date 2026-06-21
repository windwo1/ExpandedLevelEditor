using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UINuiSkeletonFeedbackWidgetData))]
	public class UINuiSkeletonFeedbackWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UINuiSkeletonFeedbackWidgetData>
	{
		public new FrostySdk.Ebx.UINuiSkeletonFeedbackWidgetData Data => data as FrostySdk.Ebx.UINuiSkeletonFeedbackWidgetData;
		public override string DisplayName => "UINuiSkeletonFeedbackWidget";

		public UINuiSkeletonFeedbackWidget(FrostySdk.Ebx.UINuiSkeletonFeedbackWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

