using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIListWidgetData))]
	public class UIListWidget : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIListWidgetData>
	{
		public new FrostySdk.Ebx.UIListWidgetData Data => data as FrostySdk.Ebx.UIListWidgetData;
		public override string DisplayName => "UIListWidget";

		public UIListWidget(FrostySdk.Ebx.UIListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

