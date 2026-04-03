using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZStatsCategoryFilterEntityData))]
	public class PVZStatsCategoryFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZStatsCategoryFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZStatsCategoryFilterEntityData Data => data as FrostySdk.Ebx.PVZStatsCategoryFilterEntityData;
		public override string DisplayName => "PVZStatsCategoryFilter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZStatsCategoryFilterEntity(FrostySdk.Ebx.PVZStatsCategoryFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

