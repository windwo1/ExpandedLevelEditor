using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderVec3PropertyEntityData))]
	public class UILegacyScreenRenderVec3PropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderVec3PropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderVec3PropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderVec3PropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderVec3Property";

		public UILegacyScreenRenderVec3PropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderVec3PropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

