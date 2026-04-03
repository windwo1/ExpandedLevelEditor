using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HashStringEntityData))]
	public class HashStringEntity : LogicEntity, IEntityData<FrostySdk.Ebx.HashStringEntityData>
	{
		public new FrostySdk.Ebx.HashStringEntityData Data => data as FrostySdk.Ebx.HashStringEntityData;
		public override string DisplayName => "HashString";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public HashStringEntity(FrostySdk.Ebx.HashStringEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

