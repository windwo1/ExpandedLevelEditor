using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorHealthStateFilterEntityData))]
	public class PVZPlayerIteratorHealthStateFilterEntity : PVZPlayerIteratorFilterEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorHealthStateFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorHealthStateFilterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorHealthStateFilterEntityData;
		public override string DisplayName => "PVZPlayerIteratorHealthStateFilter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPlayerIteratorHealthStateFilterEntity(FrostySdk.Ebx.PVZPlayerIteratorHealthStateFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

