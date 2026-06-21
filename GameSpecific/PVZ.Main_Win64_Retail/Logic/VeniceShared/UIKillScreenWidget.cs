using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIKillScreenWidgetData))]
	public class UIKillScreenWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIKillScreenWidgetData>
	{
		public new FrostySdk.Ebx.UIKillScreenWidgetData Data => data as FrostySdk.Ebx.UIKillScreenWidgetData;
		public override string DisplayName => "UIKillScreenWidget";

		public UIKillScreenWidget(FrostySdk.Ebx.UIKillScreenWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

