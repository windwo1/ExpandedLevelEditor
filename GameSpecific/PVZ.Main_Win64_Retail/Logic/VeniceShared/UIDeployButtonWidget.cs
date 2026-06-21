using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDeployButtonWidgetData))]
	public class UIDeployButtonWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIDeployButtonWidgetData>
	{
		public new FrostySdk.Ebx.UIDeployButtonWidgetData Data => data as FrostySdk.Ebx.UIDeployButtonWidgetData;
		public override string DisplayName => "UIDeployButtonWidget";

		public UIDeployButtonWidget(FrostySdk.Ebx.UIDeployButtonWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

