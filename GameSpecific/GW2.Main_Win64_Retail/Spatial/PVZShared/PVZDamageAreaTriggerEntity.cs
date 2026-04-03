using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZDamageAreaTriggerEntityData))]
	public class PVZDamageAreaTriggerEntity : DamageAreaTriggerEntity, IEntityData<FrostySdk.Ebx.PVZDamageAreaTriggerEntityData>
	{
		public new FrostySdk.Ebx.PVZDamageAreaTriggerEntityData Data => data as FrostySdk.Ebx.PVZDamageAreaTriggerEntityData;

		public PVZDamageAreaTriggerEntity(FrostySdk.Ebx.PVZDamageAreaTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

