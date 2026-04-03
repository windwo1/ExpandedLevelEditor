using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPropertyToEventEntityData))]
	public class PVZPropertyToEventEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPropertyToEventEntityData>
	{
		public new FrostySdk.Ebx.PVZPropertyToEventEntityData Data => data as FrostySdk.Ebx.PVZPropertyToEventEntityData;
		public override string DisplayName => "PVZPropertyToEvent";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPropertyToEventEntity(FrostySdk.Ebx.PVZPropertyToEventEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

