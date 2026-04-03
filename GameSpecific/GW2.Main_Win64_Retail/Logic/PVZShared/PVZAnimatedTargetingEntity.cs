using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAnimatedTargetingEntityData))]
	public class PVZAnimatedTargetingEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAnimatedTargetingEntityData>
	{
		public new FrostySdk.Ebx.PVZAnimatedTargetingEntityData Data => data as FrostySdk.Ebx.PVZAnimatedTargetingEntityData;
		public override string DisplayName => "PVZAnimatedTargeting";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZAnimatedTargetingEntity(FrostySdk.Ebx.PVZAnimatedTargetingEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

