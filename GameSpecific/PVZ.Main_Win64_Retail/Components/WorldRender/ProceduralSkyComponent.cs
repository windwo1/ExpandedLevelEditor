
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProceduralSkyComponentData))]
	public class ProceduralSkyComponent : GameComponent, IEntityData<FrostySdk.Ebx.ProceduralSkyComponentData>
	{
		public new FrostySdk.Ebx.ProceduralSkyComponentData Data => data as FrostySdk.Ebx.ProceduralSkyComponentData;
		public override string DisplayName => "ProceduralSkyComponent";

		public ProceduralSkyComponent(FrostySdk.Ebx.ProceduralSkyComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

