using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCameraEntityData))]
	public class PVZCameraEntity : CameraEntity, IEntityData<FrostySdk.Ebx.PVZCameraEntityData>
	{
		public new FrostySdk.Ebx.PVZCameraEntityData Data => data as FrostySdk.Ebx.PVZCameraEntityData;

		public PVZCameraEntity(FrostySdk.Ebx.PVZCameraEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

