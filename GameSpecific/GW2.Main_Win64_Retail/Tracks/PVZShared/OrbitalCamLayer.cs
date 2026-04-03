
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.OrbitalCamLayerData))]
	public class OrbitalCamLayer : TransformLayer, IEntityData<FrostySdk.Ebx.OrbitalCamLayerData>
	{
		public new FrostySdk.Ebx.OrbitalCamLayerData Data => data as FrostySdk.Ebx.OrbitalCamLayerData;
		public override string DisplayName => "OrbitalCamLayer";

		public OrbitalCamLayer(FrostySdk.Ebx.OrbitalCamLayerData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

