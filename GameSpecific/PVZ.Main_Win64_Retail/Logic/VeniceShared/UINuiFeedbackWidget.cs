using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UINuiFeedbackWidgetData))]
	public class UINuiFeedbackWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UINuiFeedbackWidgetData>
	{
		public new FrostySdk.Ebx.UINuiFeedbackWidgetData Data => data as FrostySdk.Ebx.UINuiFeedbackWidgetData;
		public override string DisplayName => "UINuiFeedbackWidget";

		public UINuiFeedbackWidget(FrostySdk.Ebx.UINuiFeedbackWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

