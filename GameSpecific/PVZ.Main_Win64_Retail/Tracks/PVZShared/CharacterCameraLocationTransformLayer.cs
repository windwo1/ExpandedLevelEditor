
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CharacterCameraLocationTransformLayerData))]
	public class CharacterCameraLocationTransformLayer : TransformLayer, IEntityData<FrostySdk.Ebx.CharacterCameraLocationTransformLayerData>
	{
		public new FrostySdk.Ebx.CharacterCameraLocationTransformLayerData Data => data as FrostySdk.Ebx.CharacterCameraLocationTransformLayerData;
		public override string DisplayName => "CharacterCameraLocationTransformLayer";

		public CharacterCameraLocationTransformLayer(FrostySdk.Ebx.CharacterCameraLocationTransformLayerData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

