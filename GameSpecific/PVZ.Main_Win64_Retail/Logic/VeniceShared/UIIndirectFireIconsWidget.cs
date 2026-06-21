using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIIndirectFireIconsWidgetData))]
	public class UIIndirectFireIconsWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIIndirectFireIconsWidgetData>
	{
		public new FrostySdk.Ebx.UIIndirectFireIconsWidgetData Data => data as FrostySdk.Ebx.UIIndirectFireIconsWidgetData;
		public override string DisplayName => "UIIndirectFireIconsWidget";

		public UIIndirectFireIconsWidget(FrostySdk.Ebx.UIIndirectFireIconsWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

