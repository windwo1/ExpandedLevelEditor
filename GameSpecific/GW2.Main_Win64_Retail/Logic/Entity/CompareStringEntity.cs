using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CompareStringEntityData))]
	public class CompareStringEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CompareStringEntityData>
	{
		public new FrostySdk.Ebx.CompareStringEntityData Data => data as FrostySdk.Ebx.CompareStringEntityData;
		public override string DisplayName => "CompareString";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CompareStringEntity(FrostySdk.Ebx.CompareStringEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

