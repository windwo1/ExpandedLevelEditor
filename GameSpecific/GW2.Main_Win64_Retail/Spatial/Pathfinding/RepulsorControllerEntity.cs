using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RepulsorControllerEntityData))]
	public class RepulsorControllerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.RepulsorControllerEntityData>
	{
		public new FrostySdk.Ebx.RepulsorControllerEntityData Data => data as FrostySdk.Ebx.RepulsorControllerEntityData;

		public RepulsorControllerEntity(FrostySdk.Ebx.RepulsorControllerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

