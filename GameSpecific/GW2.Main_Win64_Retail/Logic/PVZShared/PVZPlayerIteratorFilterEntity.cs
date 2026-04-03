using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorFilterEntityData))]
	public class PVZPlayerIteratorFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorFilterEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorFilterEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorFilterEntityData;
		public override string DisplayName => "PVZPlayerIteratorFilter";

		public PVZPlayerIteratorFilterEntity(FrostySdk.Ebx.PVZPlayerIteratorFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

