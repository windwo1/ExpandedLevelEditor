using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderBoolPropertyEntityData))]
	public class UILegacyScreenRenderBoolPropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderBoolPropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderBoolPropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderBoolPropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderBoolProperty";

		public UILegacyScreenRenderBoolPropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderBoolPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

