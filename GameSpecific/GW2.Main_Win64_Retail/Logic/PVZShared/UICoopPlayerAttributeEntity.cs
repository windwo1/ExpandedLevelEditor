using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICoopPlayerAttributeEntityData))]
	public class UICoopPlayerAttributeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICoopPlayerAttributeEntityData>
	{
		public new FrostySdk.Ebx.UICoopPlayerAttributeEntityData Data => data as FrostySdk.Ebx.UICoopPlayerAttributeEntityData;
		public override string DisplayName => "UICoopPlayerAttribute";

		public UICoopPlayerAttributeEntity(FrostySdk.Ebx.UICoopPlayerAttributeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

