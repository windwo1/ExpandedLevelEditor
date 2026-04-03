using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderVec4PropertyEntityData))]
	public class UILegacyScreenRenderVec4PropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderVec4PropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderVec4PropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderVec4PropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderVec4Property";

		public UILegacyScreenRenderVec4PropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderVec4PropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

