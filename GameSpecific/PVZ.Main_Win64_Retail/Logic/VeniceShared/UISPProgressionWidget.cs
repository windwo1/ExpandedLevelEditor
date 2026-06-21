using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISPProgressionWidgetData))]
	public class UISPProgressionWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISPProgressionWidgetData>
	{
		public new FrostySdk.Ebx.UISPProgressionWidgetData Data => data as FrostySdk.Ebx.UISPProgressionWidgetData;
		public override string DisplayName => "UISPProgressionWidget";

		public UISPProgressionWidget(FrostySdk.Ebx.UISPProgressionWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

