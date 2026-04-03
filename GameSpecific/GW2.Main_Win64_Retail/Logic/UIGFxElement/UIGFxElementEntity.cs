using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGFxElementEntityData))]
	public class UIGFxElementEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIGFxElementEntityData>
	{
		public new FrostySdk.Ebx.UIGFxElementEntityData Data => data as FrostySdk.Ebx.UIGFxElementEntityData;
		public override string DisplayName => "UIGFxElement";

		public UIGFxElementEntity(FrostySdk.Ebx.UIGFxElementEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

