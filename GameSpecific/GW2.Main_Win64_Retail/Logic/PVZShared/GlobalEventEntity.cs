using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GlobalEventEntityData))]
	public class GlobalEventEntity : LogicEntity, IEntityData<FrostySdk.Ebx.GlobalEventEntityData>
	{
		public new FrostySdk.Ebx.GlobalEventEntityData Data => data as FrostySdk.Ebx.GlobalEventEntityData;
		public override string DisplayName => "GlobalEvent";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public GlobalEventEntity(FrostySdk.Ebx.GlobalEventEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

