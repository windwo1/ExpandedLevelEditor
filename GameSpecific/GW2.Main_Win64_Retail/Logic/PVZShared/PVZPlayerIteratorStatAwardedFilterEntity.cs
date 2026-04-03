using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorStatAwardedFilterEntityData))]
	public class PVZPlayerIteratorStatAwardedFilterEntity : PVZPlayerIteratorFilterEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorStatAwardedFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorStatAwardedFilterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorStatAwardedFilterEntityData;
		public override string DisplayName => "PVZPlayerIteratorStatAwardedFilter";

		public PVZPlayerIteratorStatAwardedFilterEntity(FrostySdk.Ebx.PVZPlayerIteratorStatAwardedFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

