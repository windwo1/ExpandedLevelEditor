using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PointOfInterestData))]
	public class PointOfInterest : SpatialEntity, IEntityData<FrostySdk.Ebx.PointOfInterestData>
	{
		public new FrostySdk.Ebx.PointOfInterestData Data => data as FrostySdk.Ebx.PointOfInterestData;

		public PointOfInterest(FrostySdk.Ebx.PointOfInterestData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

