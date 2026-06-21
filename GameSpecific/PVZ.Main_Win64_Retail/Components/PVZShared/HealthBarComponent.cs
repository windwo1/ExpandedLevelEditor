
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HealthBarComponentData))]
	public class HealthBarComponent : GameComponent, IEntityData<FrostySdk.Ebx.HealthBarComponentData>
	{
		public new FrostySdk.Ebx.HealthBarComponentData Data => data as FrostySdk.Ebx.HealthBarComponentData;
		public override string DisplayName => "HealthBarComponent";

		public HealthBarComponent(FrostySdk.Ebx.HealthBarComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

