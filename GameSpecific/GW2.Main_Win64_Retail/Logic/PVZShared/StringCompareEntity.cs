using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.StringCompareEntityData))]
	public class StringCompareEntity : LogicEntity, IEntityData<FrostySdk.Ebx.StringCompareEntityData>
	{
		public new FrostySdk.Ebx.StringCompareEntityData Data => data as FrostySdk.Ebx.StringCompareEntityData;
		public override string DisplayName => "StringCompare";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public StringCompareEntity(FrostySdk.Ebx.StringCompareEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

