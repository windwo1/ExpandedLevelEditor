using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIConsumableSpawnMenuRootWidgetData))]
	public class UIConsumableSpawnMenuRootWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIConsumableSpawnMenuRootWidgetData>
	{
		public new FrostySdk.Ebx.UIConsumableSpawnMenuRootWidgetData Data => data as FrostySdk.Ebx.UIConsumableSpawnMenuRootWidgetData;
		public override string DisplayName => "UIConsumableSpawnMenuRootWidget";

		public UIConsumableSpawnMenuRootWidget(FrostySdk.Ebx.UIConsumableSpawnMenuRootWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

