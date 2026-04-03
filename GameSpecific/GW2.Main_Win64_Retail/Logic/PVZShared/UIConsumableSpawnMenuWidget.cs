using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIConsumableSpawnMenuWidgetData))]
	public class UIConsumableSpawnMenuWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIConsumableSpawnMenuWidgetData>
	{
		public new FrostySdk.Ebx.UIConsumableSpawnMenuWidgetData Data => data as FrostySdk.Ebx.UIConsumableSpawnMenuWidgetData;
		public override string DisplayName => "UIConsumableSpawnMenuWidget";

		public UIConsumableSpawnMenuWidget(FrostySdk.Ebx.UIConsumableSpawnMenuWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

