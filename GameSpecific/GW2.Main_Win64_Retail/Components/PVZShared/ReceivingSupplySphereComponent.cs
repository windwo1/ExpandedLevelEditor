
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ReceivingSupplySphereComponentData))]
	public class ReceivingSupplySphereComponent : GameComponent, IEntityData<FrostySdk.Ebx.ReceivingSupplySphereComponentData>
	{
		public new FrostySdk.Ebx.ReceivingSupplySphereComponentData Data => data as FrostySdk.Ebx.ReceivingSupplySphereComponentData;
		public override string DisplayName => "ReceivingSupplySphereComponent";

		public ReceivingSupplySphereComponent(FrostySdk.Ebx.ReceivingSupplySphereComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

