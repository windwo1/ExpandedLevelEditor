using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CompareIntRangeEntityData))]
	public class CompareIntRangeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CompareIntRangeEntityData>
	{
		public new FrostySdk.Ebx.CompareIntRangeEntityData Data => data as FrostySdk.Ebx.CompareIntRangeEntityData;
		public override string DisplayName => "CompareIntRange";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CompareIntRangeEntity(FrostySdk.Ebx.CompareIntRangeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

