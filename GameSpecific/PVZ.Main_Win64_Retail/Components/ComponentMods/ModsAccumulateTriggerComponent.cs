
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsAccumulateTriggerComponentData))]
	public class ModsAccumulateTriggerComponent : ModsSignalTriggerComponent, IEntityData<FrostySdk.Ebx.ModsAccumulateTriggerComponentData>
	{
		public new FrostySdk.Ebx.ModsAccumulateTriggerComponentData Data => data as FrostySdk.Ebx.ModsAccumulateTriggerComponentData;
		public override string DisplayName => "ModsAccumulateTriggerComponent";

		public ModsAccumulateTriggerComponent(FrostySdk.Ebx.ModsAccumulateTriggerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

