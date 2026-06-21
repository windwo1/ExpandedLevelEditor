using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDynamicGamertagWidgetData))]
	public class UIDynamicGamertagWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIDynamicGamertagWidgetData>
	{
		public new FrostySdk.Ebx.UIDynamicGamertagWidgetData Data => data as FrostySdk.Ebx.UIDynamicGamertagWidgetData;
		public override string DisplayName => "UIDynamicGamertagWidget";

		public UIDynamicGamertagWidget(FrostySdk.Ebx.UIDynamicGamertagWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

