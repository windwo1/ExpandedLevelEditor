
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSupplySphereComponentData))]
	public class PVZSupplySphereComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZSupplySphereComponentData>
	{
		public new FrostySdk.Ebx.PVZSupplySphereComponentData Data => data as FrostySdk.Ebx.PVZSupplySphereComponentData;
		public override string DisplayName => "PVZSupplySphereComponent";

		public PVZSupplySphereComponent(FrostySdk.Ebx.PVZSupplySphereComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

