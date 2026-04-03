using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderIntPropertyEntityData))]
	public class UILegacyScreenRenderIntPropertyEntity : UILegacyScreenRenderPropertyEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderIntPropertyEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderIntPropertyEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderIntPropertyEntityData;
		public override string DisplayName => "UILegacyScreenRenderIntProperty";

		public UILegacyScreenRenderIntPropertyEntity(FrostySdk.Ebx.UILegacyScreenRenderIntPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

