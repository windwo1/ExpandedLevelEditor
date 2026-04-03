
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZReviveSphereComponentData))]
	public class PVZReviveSphereComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZReviveSphereComponentData>
	{
		public new FrostySdk.Ebx.PVZReviveSphereComponentData Data => data as FrostySdk.Ebx.PVZReviveSphereComponentData;
		public override string DisplayName => "PVZReviveSphereComponent";

		public PVZReviveSphereComponent(FrostySdk.Ebx.PVZReviveSphereComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

