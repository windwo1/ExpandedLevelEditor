using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementEditBoxEntityData))]
	public class UIElementEditBoxEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementEditBoxEntityData>
	{
		public new FrostySdk.Ebx.UIElementEditBoxEntityData Data => data as FrostySdk.Ebx.UIElementEditBoxEntityData;
		public override string DisplayName => "UIElementEditBox";

		public UIElementEditBoxEntity(FrostySdk.Ebx.UIElementEditBoxEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

