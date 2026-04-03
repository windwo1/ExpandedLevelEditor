using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPromoteCostumeEntityData))]
	public class UIPromoteCostumeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIPromoteCostumeEntityData>
	{
		public new FrostySdk.Ebx.UIPromoteCostumeEntityData Data => data as FrostySdk.Ebx.UIPromoteCostumeEntityData;
		public override string DisplayName => "UIPromoteCostume";

		public UIPromoteCostumeEntity(FrostySdk.Ebx.UIPromoteCostumeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

