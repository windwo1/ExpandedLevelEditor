using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderFloatPropertyEntityData))]
	public class UILegacyScreenRenderFloatPropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderFloatPropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderFloatPropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderFloatPropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderFloatProperty";

		public UILegacyScreenRenderFloatPropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderFloatPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

