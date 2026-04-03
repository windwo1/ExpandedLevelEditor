using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CompareDateTimeData))]
	public class CompareDateTime : LogicEntity, IEntityData<FrostySdk.Ebx.CompareDateTimeData>
	{
		public new FrostySdk.Ebx.CompareDateTimeData Data => data as FrostySdk.Ebx.CompareDateTimeData;
		public override string DisplayName => "CompareDateTime";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CompareDateTime(FrostySdk.Ebx.CompareDateTimeData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

