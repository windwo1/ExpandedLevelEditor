using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProductInfoEntityData))]
	public class ProductInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ProductInfoEntityData>
	{
		public new FrostySdk.Ebx.ProductInfoEntityData Data => data as FrostySdk.Ebx.ProductInfoEntityData;
		public override string DisplayName => "ProductInfo";

		public ProductInfoEntity(FrostySdk.Ebx.ProductInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

