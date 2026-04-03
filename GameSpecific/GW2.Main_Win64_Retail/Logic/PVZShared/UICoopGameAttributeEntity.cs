using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICoopGameAttributeEntityData))]
	public class UICoopGameAttributeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICoopGameAttributeEntityData>
	{
		public new FrostySdk.Ebx.UICoopGameAttributeEntityData Data => data as FrostySdk.Ebx.UICoopGameAttributeEntityData;
		public override string DisplayName => "UICoopGameAttribute";

		public UICoopGameAttributeEntity(FrostySdk.Ebx.UICoopGameAttributeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

