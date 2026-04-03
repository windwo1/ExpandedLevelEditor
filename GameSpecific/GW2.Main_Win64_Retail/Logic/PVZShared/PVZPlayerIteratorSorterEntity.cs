using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorSorterEntityData))]
	public class PVZPlayerIteratorSorterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorSorterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorSorterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorSorterEntityData;
		public override string DisplayName => "PVZPlayerIteratorSorter";

		public PVZPlayerIteratorSorterEntity(FrostySdk.Ebx.PVZPlayerIteratorSorterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

