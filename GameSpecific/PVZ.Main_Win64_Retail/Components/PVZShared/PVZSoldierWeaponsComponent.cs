
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSoldierWeaponsComponentData))]
	public class PVZSoldierWeaponsComponent : SoldierWeaponsComponent, IEntityData<FrostySdk.Ebx.PVZSoldierWeaponsComponentData>
	{
		public new FrostySdk.Ebx.PVZSoldierWeaponsComponentData Data => data as FrostySdk.Ebx.PVZSoldierWeaponsComponentData;
		public override string DisplayName => "PVZSoldierWeaponsComponent";

		public PVZSoldierWeaponsComponent(FrostySdk.Ebx.PVZSoldierWeaponsComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

