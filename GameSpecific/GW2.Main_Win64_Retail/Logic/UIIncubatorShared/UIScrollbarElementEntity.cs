using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIScrollbarElementEntityData))]
	public class UIScrollbarElementEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIScrollbarElementEntityData>
	{
		public new FrostySdk.Ebx.UIScrollbarElementEntityData Data => data as FrostySdk.Ebx.UIScrollbarElementEntityData;
		public override string DisplayName => "UIScrollbarElement";

		public UIScrollbarElementEntity(FrostySdk.Ebx.UIScrollbarElementEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

