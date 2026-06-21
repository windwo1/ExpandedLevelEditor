
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSoldierHealthComponentData))]
	public class PVZSoldierHealthComponent : SoldierHealthComponent, IEntityData<FrostySdk.Ebx.PVZSoldierHealthComponentData>
	{
		public new FrostySdk.Ebx.PVZSoldierHealthComponentData Data => data as FrostySdk.Ebx.PVZSoldierHealthComponentData;
		public override string DisplayName => "PVZSoldierHealthComponent";

		public PVZSoldierHealthComponent(FrostySdk.Ebx.PVZSoldierHealthComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

