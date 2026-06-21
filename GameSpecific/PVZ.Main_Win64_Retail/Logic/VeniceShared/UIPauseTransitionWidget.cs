using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPauseTransitionWidgetData))]
	public class UIPauseTransitionWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPauseTransitionWidgetData>
	{
		public new FrostySdk.Ebx.UIPauseTransitionWidgetData Data => data as FrostySdk.Ebx.UIPauseTransitionWidgetData;
		public override string DisplayName => "UIPauseTransitionWidget";

		public UIPauseTransitionWidget(FrostySdk.Ebx.UIPauseTransitionWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

