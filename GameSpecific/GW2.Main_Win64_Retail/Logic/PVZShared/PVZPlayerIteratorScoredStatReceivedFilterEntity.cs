using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorScoredStatReceivedFilterEntityData))]
	public class PVZPlayerIteratorScoredStatReceivedFilterEntity : PVZPlayerIteratorFilterEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorScoredStatReceivedFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorScoredStatReceivedFilterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorScoredStatReceivedFilterEntityData;
		public override string DisplayName => "PVZPlayerIteratorScoredStatReceivedFilter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPlayerIteratorScoredStatReceivedFilterEntity(FrostySdk.Ebx.PVZPlayerIteratorScoredStatReceivedFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

