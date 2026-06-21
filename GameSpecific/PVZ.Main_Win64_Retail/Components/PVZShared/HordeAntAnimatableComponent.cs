
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HordeAntAnimatableComponentData))]
	public class HordeAntAnimatableComponent : LodAntAnimatableComponent, IEntityData<FrostySdk.Ebx.HordeAntAnimatableComponentData>
	{
		public new FrostySdk.Ebx.HordeAntAnimatableComponentData Data => data as FrostySdk.Ebx.HordeAntAnimatableComponentData;
		public override string DisplayName => "HordeAntAnimatableComponent";

		public HordeAntAnimatableComponent(FrostySdk.Ebx.HordeAntAnimatableComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

