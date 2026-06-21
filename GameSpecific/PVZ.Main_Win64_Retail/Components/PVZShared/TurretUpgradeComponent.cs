
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TurretUpgradeComponentData))]
	public class TurretUpgradeComponent : GameComponent, IEntityData<FrostySdk.Ebx.TurretUpgradeComponentData>
	{
		public new FrostySdk.Ebx.TurretUpgradeComponentData Data => data as FrostySdk.Ebx.TurretUpgradeComponentData;
		public override string DisplayName => "TurretUpgradeComponent";

		public TurretUpgradeComponent(FrostySdk.Ebx.TurretUpgradeComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

