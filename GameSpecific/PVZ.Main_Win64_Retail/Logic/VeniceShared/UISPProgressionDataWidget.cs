using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISPProgressionDataWidgetData))]
	public class UISPProgressionDataWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISPProgressionDataWidgetData>
	{
		public new FrostySdk.Ebx.UISPProgressionDataWidgetData Data => data as FrostySdk.Ebx.UISPProgressionDataWidgetData;
		public override string DisplayName => "UISPProgressionDataWidget";

		public UISPProgressionDataWidget(FrostySdk.Ebx.UISPProgressionDataWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

