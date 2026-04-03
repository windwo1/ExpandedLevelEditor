using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPlayerIteratorEntityData))]
	public class PVZPlayerIteratorEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPlayerIteratorEntityData>
	{
		public new FrostySdk.Ebx.PVZPlayerIteratorEntityData Data => data as FrostySdk.Ebx.PVZPlayerIteratorEntityData;
		public override string DisplayName => "PVZPlayerIterator";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPlayerIteratorEntity(FrostySdk.Ebx.PVZPlayerIteratorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

