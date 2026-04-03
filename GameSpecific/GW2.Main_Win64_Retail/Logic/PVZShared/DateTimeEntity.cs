using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DateTimeEntityData))]
	public class DateTimeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DateTimeEntityData>
	{
		public new FrostySdk.Ebx.DateTimeEntityData Data => data as FrostySdk.Ebx.DateTimeEntityData;
		public override string DisplayName => "DateTime";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public DateTimeEntity(FrostySdk.Ebx.DateTimeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

