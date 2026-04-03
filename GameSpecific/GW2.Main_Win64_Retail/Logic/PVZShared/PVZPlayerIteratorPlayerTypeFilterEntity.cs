using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorPlayerTypeFilterEntityData))]
	public class PVZPlayerIteratorPlayerTypeFilterEntity : PVZPlayerIteratorFilterEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorPlayerTypeFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorPlayerTypeFilterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorPlayerTypeFilterEntityData;
		public override string DisplayName => "PVZPlayerIteratorPlayerTypeFilter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPlayerIteratorPlayerTypeFilterEntity(FrostySdk.Ebx.PVZPlayerIteratorPlayerTypeFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

