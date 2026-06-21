using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPreRoundInfoWidgetData))]
	public class UIPreRoundInfoWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPreRoundInfoWidgetData>
	{
		public new FrostySdk.Ebx.UIPreRoundInfoWidgetData Data => data as FrostySdk.Ebx.UIPreRoundInfoWidgetData;
		public override string DisplayName => "UIPreRoundInfoWidget";

		public UIPreRoundInfoWidget(FrostySdk.Ebx.UIPreRoundInfoWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

