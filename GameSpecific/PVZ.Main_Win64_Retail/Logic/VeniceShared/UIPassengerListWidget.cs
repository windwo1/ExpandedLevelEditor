using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPassengerListWidgetData))]
	public class UIPassengerListWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPassengerListWidgetData>
	{
		public new FrostySdk.Ebx.UIPassengerListWidgetData Data => data as FrostySdk.Ebx.UIPassengerListWidgetData;
		public override string DisplayName => "UIPassengerListWidget";

		public UIPassengerListWidget(FrostySdk.Ebx.UIPassengerListWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

