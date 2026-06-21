using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDeployZoomWidgetData))]
	public class UIDeployZoomWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIDeployZoomWidgetData>
	{
		public new FrostySdk.Ebx.UIDeployZoomWidgetData Data => data as FrostySdk.Ebx.UIDeployZoomWidgetData;
		public override string DisplayName => "UIDeployZoomWidget";

		public UIDeployZoomWidget(FrostySdk.Ebx.UIDeployZoomWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

