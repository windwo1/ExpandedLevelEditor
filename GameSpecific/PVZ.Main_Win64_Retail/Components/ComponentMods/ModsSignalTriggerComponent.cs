
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsSignalTriggerComponentData))]
	public class ModsSignalTriggerComponent : ImpartOnProjectileComponent, IEntityData<FrostySdk.Ebx.ModsSignalTriggerComponentData>
	{
		public new FrostySdk.Ebx.ModsSignalTriggerComponentData Data => data as FrostySdk.Ebx.ModsSignalTriggerComponentData;
		public override string DisplayName => "ModsSignalTriggerComponent";

		public ModsSignalTriggerComponent(FrostySdk.Ebx.ModsSignalTriggerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

