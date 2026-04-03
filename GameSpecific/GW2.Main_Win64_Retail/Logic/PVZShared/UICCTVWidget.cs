using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICCTVWidgetData))]
	public class UICCTVWidget : UIWidgetEntity, IEntityData<FrostySdk.Ebx.UICCTVWidgetData>
	{
		public new FrostySdk.Ebx.UICCTVWidgetData Data => data as FrostySdk.Ebx.UICCTVWidgetData;
		public override string DisplayName => "UICCTVWidget";

		public UICCTVWidget(FrostySdk.Ebx.UICCTVWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

