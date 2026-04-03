using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderStringPropertyEntityData))]
	public class UILegacyScreenRenderStringPropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderStringPropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderStringPropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderStringPropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderStringProperty";

		public UILegacyScreenRenderStringPropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderStringPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

