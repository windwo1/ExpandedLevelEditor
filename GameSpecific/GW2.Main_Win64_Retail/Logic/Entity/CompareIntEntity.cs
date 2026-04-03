using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CompareIntEntityData))]
	public class CompareIntEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CompareIntEntityData>
	{
		public new FrostySdk.Ebx.CompareIntEntityData Data => data as FrostySdk.Ebx.CompareIntEntityData;
		public override string DisplayName => "CompareInt";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CompareIntEntity(FrostySdk.Ebx.CompareIntEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

