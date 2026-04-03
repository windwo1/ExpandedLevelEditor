using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSaveGetValueEntityData))]
	public class PVZSaveGetValueEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSaveGetValueEntityData>
	{
		public new FrostySdk.Ebx.PVZSaveGetValueEntityData Data => data as FrostySdk.Ebx.PVZSaveGetValueEntityData;
		public override string DisplayName => "PVZSaveGetValue";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZSaveGetValueEntity(FrostySdk.Ebx.PVZSaveGetValueEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

