using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SwitchPropertyLongStringEntityData))]
	public class SwitchPropertyLongStringEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SwitchPropertyLongStringEntityData>
	{
		public new FrostySdk.Ebx.SwitchPropertyLongStringEntityData Data => data as FrostySdk.Ebx.SwitchPropertyLongStringEntityData;
		public override string DisplayName => "SwitchPropertyLongString";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SwitchPropertyLongStringEntity(FrostySdk.Ebx.SwitchPropertyLongStringEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

