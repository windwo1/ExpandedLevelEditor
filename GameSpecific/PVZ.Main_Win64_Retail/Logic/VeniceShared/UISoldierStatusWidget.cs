using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISoldierStatusWidgetData))]
	public class UISoldierStatusWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISoldierStatusWidgetData>
	{
		public new FrostySdk.Ebx.UISoldierStatusWidgetData Data => data as FrostySdk.Ebx.UISoldierStatusWidgetData;
		public override string DisplayName => "UISoldierStatusWidget";

		public UISoldierStatusWidget(FrostySdk.Ebx.UISoldierStatusWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

