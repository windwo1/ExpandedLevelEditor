
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SoldierAntAnimatableComponentData))]
	public class SoldierAntAnimatableComponent : LodAntAnimatableComponent, IEntityData<FrostySdk.Ebx.SoldierAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.SoldierAntAnimatableComponentData Data => data as FrostySdk.Ebx.SoldierAntAnimatableComponentData;
		public override string DisplayName => "SoldierAntAnimatableComponent";

		public SoldierAntAnimatableComponent(FrostySdk.Ebx.SoldierAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

