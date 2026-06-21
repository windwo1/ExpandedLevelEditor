using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIMarkerEntityData))]
	public class PVZUIMarkerEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.PVZUIMarkerEntityData>
	{
		public new FrostySdk.Ebx.PVZUIMarkerEntityData Data => data as FrostySdk.Ebx.PVZUIMarkerEntityData;

		public PVZUIMarkerEntity(FrostySdk.Ebx.PVZUIMarkerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

