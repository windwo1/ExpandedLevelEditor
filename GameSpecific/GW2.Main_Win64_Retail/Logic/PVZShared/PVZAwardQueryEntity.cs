using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAwardQueryEntityData))]
	public class PVZAwardQueryEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAwardQueryEntityData>
	{
		public new FrostySdk.Ebx.PVZAwardQueryEntityData Data => data as FrostySdk.Ebx.PVZAwardQueryEntityData;
		public override string DisplayName => "PVZAwardQuery";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAwardQueryEntity(FrostySdk.Ebx.PVZAwardQueryEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

