
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZDamageReceivedModifierComponentData))]
	public class PVZDamageReceivedModifierComponent : DamageModifierComponent, IEntityData<FrostySdk.Ebx.PVZDamageReceivedModifierComponentData>
	{
		public new FrostySdk.Ebx.PVZDamageReceivedModifierComponentData Data => data as FrostySdk.Ebx.PVZDamageReceivedModifierComponentData;
		public override string DisplayName => "PVZDamageReceivedModifierComponent";

		public PVZDamageReceivedModifierComponent(FrostySdk.Ebx.PVZDamageReceivedModifierComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

