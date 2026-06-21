
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsRadialTriggerComponentData))]
	public class ModsRadialTriggerComponent : ModsSignalTriggerComponent, IEntityData<FrostySdk.Ebx.ModsRadialTriggerComponentData>
	{
		public new FrostySdk.Ebx.ModsRadialTriggerComponentData Data => data as FrostySdk.Ebx.ModsRadialTriggerComponentData;
		public override string DisplayName => "ModsRadialTriggerComponent";

		public ModsRadialTriggerComponent(FrostySdk.Ebx.ModsRadialTriggerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

