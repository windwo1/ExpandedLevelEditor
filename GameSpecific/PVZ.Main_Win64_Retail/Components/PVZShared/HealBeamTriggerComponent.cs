
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HealBeamTriggerComponentData))]
	public class HealBeamTriggerComponent : GameComponent, IEntityData<FrostySdk.Ebx.HealBeamTriggerComponentData>
	{
		public new FrostySdk.Ebx.HealBeamTriggerComponentData Data => data as FrostySdk.Ebx.HealBeamTriggerComponentData;
		public override string DisplayName => "HealBeamTriggerComponent";

		public HealBeamTriggerComponent(FrostySdk.Ebx.HealBeamTriggerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

