using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICommerceEntityData))]
	public class UICommerceEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICommerceEntityData>
	{
		public new FrostySdk.Ebx.UICommerceEntityData Data => data as FrostySdk.Ebx.UICommerceEntityData;
		public override string DisplayName => "UICommerce";

		public UICommerceEntity(FrostySdk.Ebx.UICommerceEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

