using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIServerInfoWidgetData))]
	public class UIServerInfoWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIServerInfoWidgetData>
	{
		public new FrostySdk.Ebx.UIServerInfoWidgetData Data => data as FrostySdk.Ebx.UIServerInfoWidgetData;
		public override string DisplayName => "UIServerInfoWidget";

		public UIServerInfoWidget(FrostySdk.Ebx.UIServerInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

