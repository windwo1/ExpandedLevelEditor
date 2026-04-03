using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPlayerStatusWidgetRootData))]
	public class UIPlayerStatusWidgetRoot : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIPlayerStatusWidgetRootData>
	{
		public new FrostySdk.Ebx.UIPlayerStatusWidgetRootData Data => data as FrostySdk.Ebx.UIPlayerStatusWidgetRootData;
		public override string DisplayName => "UIPlayerStatusWidgetRoot";

		public UIPlayerStatusWidgetRoot(FrostySdk.Ebx.UIPlayerStatusWidgetRootData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

