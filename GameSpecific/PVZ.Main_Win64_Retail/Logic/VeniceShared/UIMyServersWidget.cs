using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMyServersWidgetData))]
	public class UIMyServersWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMyServersWidgetData>
	{
		public new FrostySdk.Ebx.UIMyServersWidgetData Data => data as FrostySdk.Ebx.UIMyServersWidgetData;
		public override string DisplayName => "UIMyServersWidget";

		public UIMyServersWidget(FrostySdk.Ebx.UIMyServersWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

