using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectTagWidgetData))]
	public class UIObjectTagWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIObjectTagWidgetData>
	{
		public new FrostySdk.Ebx.UIObjectTagWidgetData Data => data as FrostySdk.Ebx.UIObjectTagWidgetData;
		public override string DisplayName => "UIObjectTagWidget";

		public UIObjectTagWidget(FrostySdk.Ebx.UIObjectTagWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

