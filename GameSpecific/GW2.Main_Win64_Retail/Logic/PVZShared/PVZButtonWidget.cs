using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZButtonWidgetData))]
	public class PVZButtonWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.PVZButtonWidgetData>
	{
		public new FrostySdk.Ebx.PVZButtonWidgetData Data => data as FrostySdk.Ebx.PVZButtonWidgetData;
		public override string DisplayName => "PVZButtonWidget";

		public PVZButtonWidget(FrostySdk.Ebx.PVZButtonWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

