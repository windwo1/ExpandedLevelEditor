
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSoldierCustomizationComponentData))]
	public class PVZSoldierCustomizationComponent : SoldierCustomizationComponent, IEntityData<FrostySdk.Ebx.PVZSoldierCustomizationComponentData>
	{
		public new FrostySdk.Ebx.PVZSoldierCustomizationComponentData Data => data as FrostySdk.Ebx.PVZSoldierCustomizationComponentData;
		public override string DisplayName => "PVZSoldierCustomizationComponent";

		public PVZSoldierCustomizationComponent(FrostySdk.Ebx.PVZSoldierCustomizationComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

