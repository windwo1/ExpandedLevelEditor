using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIFormatNumberEntityData))]
	public class UIFormatNumberEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIFormatNumberEntityData>
	{
		public new FrostySdk.Ebx.UIFormatNumberEntityData Data => data as FrostySdk.Ebx.UIFormatNumberEntityData;
		public override string DisplayName => "UIFormatNumber";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UIFormatNumberEntity(FrostySdk.Ebx.UIFormatNumberEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

