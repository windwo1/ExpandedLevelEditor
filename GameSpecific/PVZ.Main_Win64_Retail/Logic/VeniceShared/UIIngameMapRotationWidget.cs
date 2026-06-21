using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIIngameMapRotationWidgetData))]
	public class UIIngameMapRotationWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIIngameMapRotationWidgetData>
	{
		public new FrostySdk.Ebx.UIIngameMapRotationWidgetData Data => data as FrostySdk.Ebx.UIIngameMapRotationWidgetData;
		public override string DisplayName => "UIIngameMapRotationWidget";

		public UIIngameMapRotationWidget(FrostySdk.Ebx.UIIngameMapRotationWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

