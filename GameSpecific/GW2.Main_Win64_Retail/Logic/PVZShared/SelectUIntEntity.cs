using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SelectUIntEntityData))]
	public class SelectUIntEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SelectUIntEntityData>
	{
		public new FrostySdk.Ebx.SelectUIntEntityData Data => data as FrostySdk.Ebx.SelectUIntEntityData;
		public override string DisplayName => "SelectUInt";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SelectUIntEntity(FrostySdk.Ebx.SelectUIntEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

