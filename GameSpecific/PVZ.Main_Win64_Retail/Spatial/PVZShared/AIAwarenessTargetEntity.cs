using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIAwarenessTargetEntityData))]
	public class AIAwarenessTargetEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.AIAwarenessTargetEntityData>
	{
		public new FrostySdk.Ebx.AIAwarenessTargetEntityData Data => data as FrostySdk.Ebx.AIAwarenessTargetEntityData;
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public AIAwarenessTargetEntity(FrostySdk.Ebx.AIAwarenessTargetEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

