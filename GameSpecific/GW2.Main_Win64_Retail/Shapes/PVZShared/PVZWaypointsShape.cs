using Frosty.Core.Viewport;
using SharpDX;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZWaypointsShapeData))]
	public class PVZWaypointsShape : WaypointsShape, IEntityData<FrostySdk.Ebx.PVZWaypointsShapeData>
	{
		public new FrostySdk.Ebx.PVZWaypointsShapeData Data => data as FrostySdk.Ebx.PVZWaypointsShapeData;
		public override string DisplayName => "PVZWaypointsShape";

		public PVZWaypointsShape(FrostySdk.Ebx.PVZWaypointsShapeData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

