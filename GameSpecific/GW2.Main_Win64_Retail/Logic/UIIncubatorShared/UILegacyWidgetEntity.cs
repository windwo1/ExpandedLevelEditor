using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyWidgetEntityData))]
	public class UILegacyWidgetEntity : UIWidgetEntity, IEntityData<FrostySdk.Ebx.UILegacyWidgetEntityData>
	{
		public new FrostySdk.Ebx.UILegacyWidgetEntityData Data => data as FrostySdk.Ebx.UILegacyWidgetEntityData;
		public override string DisplayName => "UILegacyWidget";

		public UILegacyWidgetEntity(FrostySdk.Ebx.UILegacyWidgetEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

