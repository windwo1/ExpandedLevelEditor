using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUICommanderSundropsWidgetData))]
	public class PVZUICommanderSundropsWidget : UIWidgetEntity, IEntityData<FrostySdk.Ebx.PVZUICommanderSundropsWidgetData>
	{
		public new FrostySdk.Ebx.PVZUICommanderSundropsWidgetData Data => data as FrostySdk.Ebx.PVZUICommanderSundropsWidgetData;
		public override string DisplayName => "PVZUICommanderSundropsWidget";

		public PVZUICommanderSundropsWidget(FrostySdk.Ebx.PVZUICommanderSundropsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

