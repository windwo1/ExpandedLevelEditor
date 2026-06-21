using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIIngameMenuWidgetData))]
	public class UIIngameMenuWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIIngameMenuWidgetData>
	{
		public new FrostySdk.Ebx.UIIngameMenuWidgetData Data => data as FrostySdk.Ebx.UIIngameMenuWidgetData;
		public override string DisplayName => "UIIngameMenuWidget";

		public UIIngameMenuWidget(FrostySdk.Ebx.UIIngameMenuWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

