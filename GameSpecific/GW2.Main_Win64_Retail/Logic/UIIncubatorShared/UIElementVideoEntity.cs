using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementVideoEntityData))]
	public class UIElementVideoEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementVideoEntityData>
	{
		public new FrostySdk.Ebx.UIElementVideoEntityData Data => data as FrostySdk.Ebx.UIElementVideoEntityData;
		public override string DisplayName => "UIElementVideo";

		public UIElementVideoEntity(FrostySdk.Ebx.UIElementVideoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

