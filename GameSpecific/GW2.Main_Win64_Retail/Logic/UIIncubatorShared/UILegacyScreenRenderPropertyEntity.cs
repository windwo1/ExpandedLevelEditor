using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderPropertyEntityData))]
	public class UILegacyScreenRenderPropertyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderPropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderPropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderPropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderProperty";

		public UILegacyScreenRenderPropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

