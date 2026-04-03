using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorScoreSorterEntityData))]
	public class PVZPlayerIteratorScoreSorterEntity : PVZPlayerIteratorSorterEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorScoreSorterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorScoreSorterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorScoreSorterEntityData;
		public override string DisplayName => "PVZPlayerIteratorScoreSorter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPlayerIteratorScoreSorterEntity(FrostySdk.Ebx.PVZPlayerIteratorScoreSorterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

