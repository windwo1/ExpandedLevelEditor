
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterBodyComponentData))]
	public class PVZCharacterBodyComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterBodyComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterBodyComponentData Data => data as FrostySdk.Ebx.PVZCharacterBodyComponentData;
		public override string DisplayName => "PVZCharacterBodyComponent";

		public PVZCharacterBodyComponent(FrostySdk.Ebx.PVZCharacterBodyComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

