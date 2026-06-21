using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIJavelinWidgetData))]
	public class UIJavelinWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIJavelinWidgetData>
	{
		public new FrostySdk.Ebx.UIJavelinWidgetData Data => data as FrostySdk.Ebx.UIJavelinWidgetData;
		public override string DisplayName => "UIJavelinWidget";

		public UIJavelinWidget(FrostySdk.Ebx.UIJavelinWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

