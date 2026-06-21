using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIVoipStatusWidgetData))]
	public class UIVoipStatusWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIVoipStatusWidgetData>
	{
		public new FrostySdk.Ebx.UIVoipStatusWidgetData Data => data as FrostySdk.Ebx.UIVoipStatusWidgetData;
		public override string DisplayName => "UIVoipStatusWidget";

		public UIVoipStatusWidget(FrostySdk.Ebx.UIVoipStatusWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

