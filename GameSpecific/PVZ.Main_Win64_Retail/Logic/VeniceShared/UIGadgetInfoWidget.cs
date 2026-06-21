using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGadgetInfoWidgetData))]
	public class UIGadgetInfoWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIGadgetInfoWidgetData>
	{
		public new FrostySdk.Ebx.UIGadgetInfoWidgetData Data => data as FrostySdk.Ebx.UIGadgetInfoWidgetData;
		public override string DisplayName => "UIGadgetInfoWidget";

		public UIGadgetInfoWidget(FrostySdk.Ebx.UIGadgetInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

