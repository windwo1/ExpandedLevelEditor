using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIRevivalScreenWidgetData))]
	public class UIRevivalScreenWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIRevivalScreenWidgetData>
	{
		public new FrostySdk.Ebx.UIRevivalScreenWidgetData Data => data as FrostySdk.Ebx.UIRevivalScreenWidgetData;
		public override string DisplayName => "UIRevivalScreenWidget";

		public UIRevivalScreenWidget(FrostySdk.Ebx.UIRevivalScreenWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

