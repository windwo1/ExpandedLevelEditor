using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPitchLadderWidgetData))]
	public class UIPitchLadderWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPitchLadderWidgetData>
	{
		public new FrostySdk.Ebx.UIPitchLadderWidgetData Data => data as FrostySdk.Ebx.UIPitchLadderWidgetData;
		public override string DisplayName => "UIPitchLadderWidget";

		public UIPitchLadderWidget(FrostySdk.Ebx.UIPitchLadderWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

