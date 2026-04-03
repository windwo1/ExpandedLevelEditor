
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterJumpChargeComponentData))]
	public class PVZCharacterJumpChargeComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterJumpChargeComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterJumpChargeComponentData Data => data as FrostySdk.Ebx.PVZCharacterJumpChargeComponentData;
		public override string DisplayName => "PVZCharacterJumpChargeComponent";

		public PVZCharacterJumpChargeComponent(FrostySdk.Ebx.PVZCharacterJumpChargeComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

