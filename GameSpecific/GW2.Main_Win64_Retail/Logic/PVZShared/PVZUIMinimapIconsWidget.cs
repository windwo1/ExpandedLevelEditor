using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIMinimapIconsWidgetData))]
	public class PVZUIMinimapIconsWidget : UIWidgetEntity, IEntityData<FrostySdk.Ebx.PVZUIMinimapIconsWidgetData>
	{
		public new FrostySdk.Ebx.PVZUIMinimapIconsWidgetData Data => data as FrostySdk.Ebx.PVZUIMinimapIconsWidgetData;
		public override string DisplayName => "PVZUIMinimapIconsWidget";

		public PVZUIMinimapIconsWidget(FrostySdk.Ebx.PVZUIMinimapIconsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

