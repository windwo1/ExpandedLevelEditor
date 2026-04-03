using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SelectEnumerationEntityData))]
	public class SelectEnumerationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SelectEnumerationEntityData>
	{
		public new FrostySdk.Ebx.SelectEnumerationEntityData Data => data as FrostySdk.Ebx.SelectEnumerationEntityData;
		public override string DisplayName => "SelectEnumeration";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SelectEnumerationEntity(FrostySdk.Ebx.SelectEnumerationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

