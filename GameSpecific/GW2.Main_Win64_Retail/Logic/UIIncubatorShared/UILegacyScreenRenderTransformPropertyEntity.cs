using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderTransformPropertyEntityData))]
	public class UILegacyScreenRenderTransformPropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderTransformPropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderTransformPropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderTransformPropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderTransformProperty";

		public UILegacyScreenRenderTransformPropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderTransformPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

