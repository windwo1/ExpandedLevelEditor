using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementDummyEntityData))]
	public class UIElementDummyEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementDummyEntityData>
	{
		public new FrostySdk.Ebx.UIElementDummyEntityData Data => data as FrostySdk.Ebx.UIElementDummyEntityData;
		public override string DisplayName => "UIElementDummy";

		public UIElementDummyEntity(FrostySdk.Ebx.UIElementDummyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

