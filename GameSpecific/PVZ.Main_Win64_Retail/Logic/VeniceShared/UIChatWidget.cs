using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIChatWidgetData))]
	public class UIChatWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIChatWidgetData>
	{
		public new FrostySdk.Ebx.UIChatWidgetData Data => data as FrostySdk.Ebx.UIChatWidgetData;
		public override string DisplayName => "UIChatWidget";

		public UIChatWidget(FrostySdk.Ebx.UIChatWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

