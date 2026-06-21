using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUICommanderWidgetData))]
	public class PVZUICommanderWidget : UIWidgetEntity, IEntityData<FrostySdk.Ebx.PVZUICommanderWidgetData>
	{
		public new FrostySdk.Ebx.PVZUICommanderWidgetData Data => data as FrostySdk.Ebx.PVZUICommanderWidgetData;
		public override string DisplayName => "PVZUICommanderWidget";

		public PVZUICommanderWidget(FrostySdk.Ebx.PVZUICommanderWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

