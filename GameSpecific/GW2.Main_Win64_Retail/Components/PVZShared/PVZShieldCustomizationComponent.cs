
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZShieldCustomizationComponentData))]
	public class PVZShieldCustomizationComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZShieldCustomizationComponentData>
	{
		public new FrostySdk.Ebx.PVZShieldCustomizationComponentData Data => data as FrostySdk.Ebx.PVZShieldCustomizationComponentData;
		public override string DisplayName => "PVZShieldCustomizationComponent";

		public PVZShieldCustomizationComponent(FrostySdk.Ebx.PVZShieldCustomizationComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

