using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISoldierProgressionGridWidgetData))]
	public class UISoldierProgressionGridWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISoldierProgressionGridWidgetData>
	{
		public new FrostySdk.Ebx.UISoldierProgressionGridWidgetData Data => data as FrostySdk.Ebx.UISoldierProgressionGridWidgetData;
		public override string DisplayName => "UISoldierProgressionGridWidget";

		public UISoldierProgressionGridWidget(FrostySdk.Ebx.UISoldierProgressionGridWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

