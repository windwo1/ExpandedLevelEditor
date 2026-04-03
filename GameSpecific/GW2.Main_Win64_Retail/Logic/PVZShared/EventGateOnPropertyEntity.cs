using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.EventGateOnPropertyEntityData))]
	public class EventGateOnPropertyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.EventGateOnPropertyEntityData>
	{
		public new FrostySdk.Ebx.EventGateOnPropertyEntityData Data => data as FrostySdk.Ebx.EventGateOnPropertyEntityData;
		public override string DisplayName => "EventGateOnProperty";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public EventGateOnPropertyEntity(FrostySdk.Ebx.EventGateOnPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

