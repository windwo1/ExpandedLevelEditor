using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPackInfoEntityData))]
	public class PVZPackInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPackInfoEntityData>
	{
		public new FrostySdk.Ebx.PVZPackInfoEntityData Data => data as FrostySdk.Ebx.PVZPackInfoEntityData;
		public override string DisplayName => "PVZPackInfo";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPackInfoEntity(FrostySdk.Ebx.PVZPackInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

