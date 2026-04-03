using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BillboardEntityData))]
	public class BillboardEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BillboardEntityData>
	{
		public new FrostySdk.Ebx.BillboardEntityData Data => data as FrostySdk.Ebx.BillboardEntityData;
		public override string DisplayName => "Billboard";

		public BillboardEntity(FrostySdk.Ebx.BillboardEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

