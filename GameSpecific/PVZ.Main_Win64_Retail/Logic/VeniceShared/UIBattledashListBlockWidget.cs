using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIBattledashListBlockWidgetData))]
	public class UIBattledashListBlockWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIBattledashListBlockWidgetData>
	{
		public new FrostySdk.Ebx.UIBattledashListBlockWidgetData Data => data as FrostySdk.Ebx.UIBattledashListBlockWidgetData;
		public override string DisplayName => "UIBattledashListBlockWidget";

		public UIBattledashListBlockWidget(FrostySdk.Ebx.UIBattledashListBlockWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

