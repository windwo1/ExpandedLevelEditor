using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKillCardBarWidgetData))]
	public class UIKillCardBarWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIKillCardBarWidgetData>
	{
		public new FrostySdk.Ebx.UIKillCardBarWidgetData Data => data as FrostySdk.Ebx.UIKillCardBarWidgetData;
		public override string DisplayName => "UIKillCardBarWidget";

		public UIKillCardBarWidget(FrostySdk.Ebx.UIKillCardBarWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

