using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SelectAntEnumerationEntityData))]
	public class SelectAntEnumerationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SelectAntEnumerationEntityData>
	{
		public new FrostySdk.Ebx.SelectAntEnumerationEntityData Data => data as FrostySdk.Ebx.SelectAntEnumerationEntityData;
		public override string DisplayName => "SelectAntEnumeration";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SelectAntEnumerationEntity(FrostySdk.Ebx.SelectAntEnumerationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

