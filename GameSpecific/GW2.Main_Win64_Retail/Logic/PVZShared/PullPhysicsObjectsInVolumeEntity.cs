using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PullPhysicsObjectsInVolumeEntityData))]
	public class PullPhysicsObjectsInVolumeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PullPhysicsObjectsInVolumeEntityData>
	{
		public new FrostySdk.Ebx.PullPhysicsObjectsInVolumeEntityData Data => data as FrostySdk.Ebx.PullPhysicsObjectsInVolumeEntityData;
		public override string DisplayName => "PullPhysicsObjectsInVolume";

		public PullPhysicsObjectsInVolumeEntity(FrostySdk.Ebx.PullPhysicsObjectsInVolumeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

