using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffTrackingEntityData))]
	public class BuffTrackingEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BuffTrackingEntityData>
	{
		public new FrostySdk.Ebx.BuffTrackingEntityData Data => data as FrostySdk.Ebx.BuffTrackingEntityData;
		public override string DisplayName => "BuffTracking";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public BuffTrackingEntity(FrostySdk.Ebx.BuffTrackingEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

