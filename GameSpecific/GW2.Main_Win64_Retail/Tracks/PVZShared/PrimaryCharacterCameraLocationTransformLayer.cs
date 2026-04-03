
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PrimaryCharacterCameraLocationTransformLayerData))]
	public class PrimaryCharacterCameraLocationTransformLayer : TransformLayer, IEntityData<FrostySdk.Ebx.PrimaryCharacterCameraLocationTransformLayerData>
	{
		public new FrostySdk.Ebx.PrimaryCharacterCameraLocationTransformLayerData Data => data as FrostySdk.Ebx.PrimaryCharacterCameraLocationTransformLayerData;
		public override string DisplayName => "PrimaryCharacterCameraLocationTransformLayer";

		public PrimaryCharacterCameraLocationTransformLayer(FrostySdk.Ebx.PrimaryCharacterCameraLocationTransformLayerData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

