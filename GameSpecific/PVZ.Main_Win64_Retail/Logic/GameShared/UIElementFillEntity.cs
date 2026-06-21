using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementFillEntityData))]
	public class UIElementFillEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementFillEntityData>
	{
		public new FrostySdk.Ebx.UIElementFillEntityData Data => data as FrostySdk.Ebx.UIElementFillEntityData;
		public override string DisplayName => "UIElementFill";

		public UIElementFillEntity(FrostySdk.Ebx.UIElementFillEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

