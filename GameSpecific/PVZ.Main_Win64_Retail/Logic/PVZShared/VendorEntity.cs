using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.VendorEntityData))]
	public class VendorEntity : LogicEntity, IEntityData<FrostySdk.Ebx.VendorEntityData>
	{
		public new FrostySdk.Ebx.VendorEntityData Data => data as FrostySdk.Ebx.VendorEntityData;
		public override string DisplayName => "Vendor";

		public VendorEntity(FrostySdk.Ebx.VendorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

