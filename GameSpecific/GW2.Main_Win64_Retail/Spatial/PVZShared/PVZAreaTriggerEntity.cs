using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAreaTriggerEntityData))]
	public class PVZAreaTriggerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.PVZAreaTriggerEntityData>
	{
		public new FrostySdk.Ebx.PVZAreaTriggerEntityData Data => data as FrostySdk.Ebx.PVZAreaTriggerEntityData;
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAreaTriggerEntity(FrostySdk.Ebx.PVZAreaTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

