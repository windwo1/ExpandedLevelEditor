using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorTeamFilterEntityData))]
	public class PVZPlayerIteratorTeamFilterEntity : PVZPlayerIteratorFilterEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorTeamFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorTeamFilterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorTeamFilterEntityData;
		public override string DisplayName => "PVZPlayerIteratorTeamFilter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPlayerIteratorTeamFilterEntity(FrostySdk.Ebx.PVZPlayerIteratorTeamFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

