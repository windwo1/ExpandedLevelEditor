using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementButtonEntityData))]
	public class UIElementButtonEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementButtonEntityData>
	{
		public new FrostySdk.Ebx.UIElementButtonEntityData Data => data as FrostySdk.Ebx.UIElementButtonEntityData;
		public override string DisplayName => "UIElementButton";

		public UIElementButtonEntity(FrostySdk.Ebx.UIElementButtonEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

