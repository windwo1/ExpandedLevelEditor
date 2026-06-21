
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TurretAntAnimatableComponentData))]
	public class TurretAntAnimatableComponent : LodAntAnimatableComponent, IEntityData<FrostySdk.Ebx.TurretAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.TurretAntAnimatableComponentData Data => data as FrostySdk.Ebx.TurretAntAnimatableComponentData;
		public override string DisplayName => "TurretAntAnimatableComponent";

		public TurretAntAnimatableComponent(FrostySdk.Ebx.TurretAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

