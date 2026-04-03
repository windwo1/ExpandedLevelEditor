using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILegacyScreenRenderEntityData))]
	public class UILegacyScreenRenderEntity : UIScreenRenderEntity, IEntityData<FrostySdk.Ebx.UILegacyScreenRenderEntityData>
	{
		public new FrostySdk.Ebx.UILegacyScreenRenderEntityData Data => data as FrostySdk.Ebx.UILegacyScreenRenderEntityData;

		public UILegacyScreenRenderEntity(FrostySdk.Ebx.UILegacyScreenRenderEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

