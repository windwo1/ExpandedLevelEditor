using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGameModeEventWidgetData))]
	public class UIGameModeEventWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIGameModeEventWidgetData>
	{
		public new FrostySdk.Ebx.UIGameModeEventWidgetData Data => data as FrostySdk.Ebx.UIGameModeEventWidgetData;
		public override string DisplayName => "UIGameModeEventWidget";

		public UIGameModeEventWidget(FrostySdk.Ebx.UIGameModeEventWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

